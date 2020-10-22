using System;
using System.Collections.Generic;

public class BubState :IState
{
    public string Name { get; set; }
    
    public Action OnEnter { get; set; }
    public Action<float> OnUpdate { get; set; }
    public Action OnExit { get; set; }

    private List<ITranslation> _translations;
    public List<ITranslation> Translations
    {
        get => _translations ?? (_translations = new List<ITranslation>());
        set => _translations = value;
    }

    public BubState(string name,Action onEnter,Action<float> onUpdate,Action onExit,IStateController controller)
    {
        this.Name = name;
        this.OnEnter = onEnter;
        this.OnUpdate = onUpdate;
        this.OnExit = onExit;
        
        controller.AddState(this);
    }

    public void AddStateTranslation(ITranslation translation)
    {
        if (!Translations.Contains(translation))
        {
            Translations.Add(translation);
        }
    }
}
