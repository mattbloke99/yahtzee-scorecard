# Yahtzee Score Tracker

A simple, web-based score tracking application for physical Yahtzee games built with Blazor WebAssembly and MudBlazor.

## Overview

This application helps you track scores for Yahtzee games played with real dice. Players roll physical dice and manually enter their scores into the app, which automatically calculates totals, bonuses, and grand totals for each player.

## Features

- **Multiple Players**: Support for 1-8 players in a single game
- **Unified Score Table**: All players displayed in one table for easy score comparison
- **Auto-calculated Totals**: Real-time calculation of:
  - Upper section totals
  - Upper bonus (35 points when upper total ≥ 63)
  - Lower section totals
  - Grand totals
- **Yahtzee Bonuses**: Track up to 6 Yahtzee bonuses per player (100 points each)
- **Mobile-Friendly**: Responsive design with narrow input fields optimized for mobile screens
- **No Persistence**: Simple session-based tracking - no game saving/loading
- **Clean Interface**: Minimal design with no header or navigation

## Scoring Categories

### Upper Section
- **Ones** (formerly Aces): Count and add only ones (0-5)
- **Twos**: Count and add only twos (0, 2, 4, 6, 8, 10)
- **Threes**: Count and add only threes (0, 3, 6, 9, 12, 15)
- **Fours**: Count and add only fours (0, 4, 8, 12, 16, 20)
- **Fives**: Count and add only fives (0, 5, 10, 15, 20, 25)
- **Sixes**: Count and add only sixes (0, 6, 12, 18, 24, 30)

**Bonus**: If upper section total ≥ 63, receive 35 bonus points

### Lower Section
- **3 of a Kind**: Three dice the same - total of all dice (0-30)
- **4 of a Kind**: Four dice the same - total of all dice (0-30)
- **Full House**: Three of one number and two of another (25 points)
- **Small Straight**: Four sequential dice (30 points)
- **Large Straight**: Five sequential dice (40 points)
- **Yahtzee**: All five dice the same (50 points)
- **Chance**: Any combination - total of all dice (0-30)
- **Yahtzee Bonuses**: Additional Yahtzees after first (100 points each)

## How to Use

1. **Start the Application**
   ```bash
   cd Yahtzee
   dotnet run
   ```
   Navigate to http://localhost:5118

2. **Setup Game**
   - Select number of players (1-8)
   - Enter player names (defaults to "Player 1", "Player 2", etc.)
   - Click "Start Game"

3. **Enter Scores**
   - Each player has their own column in the score table
   - Use dropdowns for upper section (valid values only)
   - Use number inputs for variable lower section scores
   - Use checkboxes for fixed-value categories
   - Track Yahtzee bonuses with numbered checkboxes

4. **Manage Game**
   - **Clear All Scores**: Reset all player scores to start fresh
   - **New Game**: Return to setup screen to create a new game with different players

## Technical Details

### Technology Stack
- **Blazor WebAssembly**: Client-side web framework
- **MudBlazor 8.15.0**: Material Design component library
- **.NET 10.0**: Runtime framework

### Project Structure
```
Yahtzee/
├── Models/
│   ├── Player.cs - Player with name and scores
│   ├── YahtzeeScore.cs - Score data with calculated totals
│   └── Game.cs - Game model (legacy, not used)
├── Services/
│   └── ScoreService.cs - Score validation and possible values
├── Components/
│   ├── MultiPlayerScoreCard.razor - Unified multi-player score table
│   ├── UpperSectionRow.razor - Single player upper section row
│   ├── LowerSectionFixedRow.razor - Fixed value checkbox row
│   ├── LowerSectionVariableRow.razor - Variable value input row
│   └── YahtzeeBonusRow.razor - Bonus checkboxes
├── Pages/
│   └── Index.razor - Main page with setup and scoring
└── wwwroot/
    └── css/app.css - Custom styles
```

### Key Components

**MultiPlayerScoreCard.razor**
- Displays all players in a single unified table
- First column: category names
- Remaining columns: one per player with their inputs
- Real-time total calculations

**Index.razor**
- Game setup form (number of players, names)
- Hosts the MultiPlayerScoreCard component
- Clear/New Game controls

### Building and Running

**Prerequisites**
- .NET 10.0 SDK or later

**Build**
```bash
dotnet build
```

**Run**
```bash
dotnet run
```

**Publish for Production**
```bash
dotnet publish -c Release
```

## Design Decisions

- **No Persistence**: Simplified UX - just enter scores without managing saved games
- **Unified Table**: All players visible at once for easy comparison
- **Narrow Inputs**: Optimized for mobile screens with 80px max-width fields
- **Dropdown Validation**: Upper section uses dropdowns with only valid values (prevents errors)
- **Real-time Calculations**: All totals update immediately as scores are entered

## Browser Compatibility

Works in all modern browsers supporting WebAssembly:
- Chrome/Edge (recommended)
- Firefox
- Safari

## License

This is a personal project for tracking Yahtzee scores.
