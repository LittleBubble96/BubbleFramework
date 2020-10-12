using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleFramework.Bubble_Event
{
    public class EventType
    {
        public string Type;

        protected EventType()
        {
            
        }

        public EventType(string type)
        {
            Type = type;
        }
    }

    public class MultiEvent<T> : EventType
    {
        public T Value { get; set; }
        
        public MultiEvent(string type, T value)
        {
            this.Type = type;
            this.Value = value;
        }

    } 
    
    public class MultiEvent<T,T1> : MultiEvent<T>
    {
        public T1 Value1 { get; set; }

        public MultiEvent(string type, T value,T1 value1) : base(type,value)
        {
            this.Value1 = value1;
        }
    }
    
    public class MultiEvent<T,T1,T2> : MultiEvent<T,T1>
    {
        public T2 Value2 { get; set; }

        public MultiEvent(string type, T value,T1 value1,T2 value2) : base(type,value,value1)
        {
            this.Value2 = value2;
        }
    }
    
}

