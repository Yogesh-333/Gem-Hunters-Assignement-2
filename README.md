# Gem Hunters Assignement 2

Gem Hunters is a console-based 2D game where players compete to collect the most gems within a set number of turns on a 6x6 board filled with gems and obstacles.

## Table of Contents

- [Game Overview](#game-overview)
- [Installation](#installation)
- [How to Play](#how-to-play)
- [Classes and Structure](#classes-and-structure)

## Game Overview

- **Players**: 2 (Player 1 and Player 2)
- **Board Size**: 6x6 grid
- **Objective**: Collect the most gems within 15 turns per player (30 turns total).
- **Game Elements**:
  - Players: Player 1 starts in the top-left corner and Player 2 starts in the bottom-right corner.
  - Gems: Randomly placed on the board at the start of the game.
  - Obstacles: Randomly placed on the board at the start of the game, cannot be passed through.

## Installation

1. Clone the repository to your local machine:
    ```sh
    git clone https://github.com/yourusername/gem-hunters.git
    ```
2. Navigate to the project directory:
    ```sh
    cd gem-hunters
    ```
3. Build the project using your preferred C# IDE (e.g., Visual Studio) or the .NET CLI:
    ```sh
    dotnet build
    ```

## How to Play

1. Run the game:
    ```sh
    dotnet run
    ```
2. The game will display the board and the current player's turn.
3. Players take turns entering a direction to move:
    - **U**: Up
    - **D**: Down
    - **L**: Left
    - **R**: Right
4. Players collect gems by moving onto a square containing a gem.
5. The game ends when either all gems are collected or the maximum number of turns (30) is reached.
6. The player with the most gems at the end wins. If both players have the same number of gems, it's a tie.

## Classes and Structure

- **Position**: Represents the x and y coordinates on the board.
- **Player**: Represents a player with properties for name, position, and gem count.
- **Cell**: Represents a cell on the board which can be empty, contain a player, gem, or obstacle.
- **Board**: Manages the game board, including initialization, displaying the board, and validating moves.
- **Game**: Manages the overall game flow, including turns, collecting gems, and determining the winner.

### File Structure

- `Position.cs`: Defines the `Position` class.
- `Player.cs`: Defines the `Player` class.
- `Cell.cs`: Defines the `Cell` class.
- `Board.cs`: Defines the `Board` class.
- `Game.cs`: Defines the `Game` class.
- `Program.cs`: Entry point of the application.

