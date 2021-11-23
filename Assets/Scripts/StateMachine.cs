using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private IState curState;
    private Dictionary<Type, List<Transition>> transitions = new Dictionary<Type, List<Transition>>();
    private List<Transition> curTransitions = new List<Transition>();
    private List<Transition> anyTransitions = new List<Transition>();
    private static List<Transition> emptyTransitions = new List<Transition>(0);
    public void Tick()
    {
        var transition = GetTransition();
        if (transition != null)
            SetState(transition.To);
            
        curState?.Tick();
    }

    public void SetState(IState state)
    {
        if (curState == state)
            return;

        curState?.OnExit();
        curState = state;

        transitions.TryGetValue(curState.GetType(), out curTransitions);
        if (curTransitions == null)
            curTransitions = emptyTransitions;

        curState.OnEnter();
    }

    public void AddTransition(IState from, IState to, Func<bool> check)
    {
        if (transitions.TryGetValue(from.GetType(), out var transitions_) == false)
        {
            transitions_ = new List<Transition>();
            transitions[from.GetType()] = transitions_;
        }

        transitions_.Add(new Transition(to, check));
    }

    public void AddAnyTransition(IState from, IState to, Func<bool> check)
    {
        anyTransitions.Add(new Transition(to, check));
    }


    private Transition GetTransition()
    {
        foreach (var transition in anyTransitions)
        {
            if (transition.Check())
            {
                return transition;
            }
        }

        foreach (var transition in curTransitions)
        {
            if (transition.Check())
            {
                return transition;
            }
        }

        return null;
    }

    private class Transition
    {
        public IState To { get; set; }
        public Func<bool> Check { get; }

        public Transition(IState to, Func<bool> func)
        {
            To = to;
            Check = func;
        }
    }
}
