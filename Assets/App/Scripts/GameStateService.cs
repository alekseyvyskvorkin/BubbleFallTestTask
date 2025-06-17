using Game.Enums;
using System;

public class GameStateService 
{
    public GameState GameState { get; private set; }

    public Action OnStartPlay { get; set; }
    public Action OnFailGame { get; set; }
    public Action OnWinGame { get; set; }
    public Action OnWaiting {  get; set; }

    public GameStateService()
    {
        GameState = GameState.Waiting;
        OnStartPlay += OnStart;
        OnFailGame += OnFail;
        OnWinGame += OnWin;
        OnWaiting += OnWait;
        OnWaiting?.Invoke();
    }

    private void OnStart() => GameState = GameState.Playing;
    private void OnFail() => GameState = GameState.Lose;
    private void OnWin() => GameState = GameState.Win;
    private void OnWait() => GameState = GameState.Waiting;
}
