﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Contracts;
using Game_Logic.Enums;
using Game_Logic.Packets;

namespace Game_Logic
{
    public class GameManager
    {
        private Gameboard gameboard;
        private Player[] players;
        private Player activePlayer;
        private bool gameFinished;
        private Random random;
        private IClientContract clientContract;

        public GameManager(IClientContract clientContract)
        {
            this.clientContract = clientContract;
            this.Initialization();
        }
        public void StartGame()
        {
            var gameStatus = new GameStatus(this.gameboard.Cells, this.players);
            this.clientContract.HandleGameChanged(gameStatus);
            while (!this.gameFinished)
            {
                this.HandleMove(this.activePlayer);
                this.SetNextActivePlayer();
            }
        }

        private void HandleMove(Player player)
        {
            if (player.ActiveFigures.Count == 0) { this.HandlePlayerWithNoActiveFigures(player); }
            else { this.HandlePlayerWithActiveFigures(player); }
        }

        private void HandlePlayerWithActiveFigures(Player player)
        {
            int dice = this.RollDice();

            if (dice == 6 && player.FiguresAtStart.Count > 0) { this.HandlePlayerWithActiveFiguresAndDice6(dice, player); return; }
            
            FigureEnum figureInput = this.clientContract.GetUserInput(dice, player.ID, player.ActiveFigures);
            
            int oldPos = this.gameboard.GetPosOfPlayersFigure(player.ID, figureInput);
            this.gameboard.Cells[oldPos].RemovePlayer();
            
            int newPos = this.CalculateNewPos(oldPos, dice);
            
            //if (this.gameboard.Cells[newPos].Player != PlayerEnum.NoPlayer)
            //{ 
            //    var oldplayer = this.GetPlayerByPlayerEnum(this.gameboard.Cells[newPos].Player);
            //    var oldPlayerFigure = this.gameboard.Cells[newPos].Figure;
            //    oldplayer.DecreaseActiveFiguresAndIncreaseStartFigures(oldPlayerFigure);
            //}


            this.UpdatePlayerAndGameboardFigures(newPos, player, figureInput);
        }

        private int CalculateNewPos(int oldPos, int newPos)
        {
            if (oldPos + newPos > 39) { return (oldPos + newPos) - 40; }
            return oldPos + newPos;
        }

        private void HandlePlayerWithActiveFiguresAndDice6(int dice, Player player)
        {
            FigureEnum input = this.clientContract.GetUserInput(dice, player.ID, player.FiguresAtStart);
            int pos = this.gameboard.GetPlayerStartingPosition(player.ID);
            if (this.gameboard.Cells[pos].Player != PlayerEnum.NoPlayer)
            {
                var oldFigureID = this.gameboard.Cells[pos].Figure;
                var oldPlayerID = this.gameboard.Cells[pos].Player;
                var oldPlayer = this.GetPlayerByPlayerEnum(oldPlayerID);
                oldPlayer.DecreaseActiveFiguresAndIncreaseStartFigures(oldFigureID);
            }

            this.gameboard.Cells[pos].SetPlayerAndFigure(player.ID, input);
            player.DecreaseFiguresAtStart(input);
            this.NotifyClient(new GameStatus(this.gameboard.Cells, this.players));
        }

        private void HandlePlayerWithNoActiveFigures(Player player)
        {
            for (int i = 0; i < 3; i++)
            {
                int dice = this.RollDice();
                if (dice == 6)
                {
                    FigureEnum figureInput = this.clientContract.GetUserInput(dice, player.ID, player.FiguresAtStart);

                    player.DecreaseFiguresAtStart(figureInput);
                    this.UpdatePlayerAndGameboardFigures(this.gameboard.GetPlayerStartingPosition(player.ID), player, figureInput);
                    break;
                }
            }
        }

        private void UpdatePlayerAndGameboardFigures(int pos, Player player, FigureEnum figure)
        {
            //if (this.gameboard.Cells[pos].Player == PlayerEnum.NoPlayer) 
            //{ 
            //    player.DecreaseFiguresAtStart(figure);
            //}
            if (this.gameboard.Cells[pos].Player != PlayerEnum.NoPlayer)
            {
                var oldFigure = this.gameboard.Cells[pos].Figure;
                var oldPlayer = this.GetPlayerByPlayerEnum(this.gameboard.Cells[pos].Player);
                oldPlayer.DecreaseActiveFiguresAndIncreaseStartFigures(oldFigure);                
            }

            this.gameboard.Cells[pos].SetPlayerAndFigure(player.ID, figure);
            
            this.NotifyClient(new GameStatus(this.gameboard.Cells, this.players));
        }

        private void NotifyClient(GameStatus gameStatus)
        {
            this.clientContract.HandleGameChanged(gameStatus);
        }

        private Player GetPlayerByPlayerEnum(PlayerEnum playerID)
        {
            foreach (var player in this.players)
            {
                if (player.ID == playerID)
                {
                    return player;
                }
            }

            throw new Exception("Invalid Player ID");
        }

        private int RollDice() { return this.random.Next(1,7); }

        private void SetNextActivePlayer()
        {
            int pos = 0;
            for (int i = 0; i < 4; i++)
            {
                if (this.players[i]== this.activePlayer)
                {
                    pos = i;
                    break;
                }
            }

            if (pos == 3) { this.activePlayer = this.players[0]; }
            else { pos++;  this.activePlayer = this.players[pos];  }
        }

        private void Initialization()
        {
            this.gameboard = new Gameboard();
            this.gameFinished = false;
            this.players = new Player[4];
            for (int i = 0; i < 4; i++) { var newCounter = i + 1;  this.players[i] = new Player(newCounter); }
            this.activePlayer = this.players[0];
            this.random = new Random();
        }
    }
}
