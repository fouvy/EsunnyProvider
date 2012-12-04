using System;
using System.Collections.Generic;
using System.Text;

namespace CalmBeltFund.Trading.Esunny
{

  //public delegate void EventHandler<T>(EsunnyTrader trader, T args);

  public class EsunnyEventArgs : EventArgs
  {

  }

  public class EsunnyEventArgs<T> : EsunnyEventArgs
  {
    
    T value;

    public T Value
    {
      get { return this.value; }
      set { this.value = value; }
    }

    internal EsunnyEventArgs(T value)
    {
      this.value = value;
    }
  }


  public class EventProcessor
  {
    //public static void BeginInvoke<T>(EventHandler<T> @event, object sender, T e) where T : EventArgs
    //{
    //  EventHandler<T> handler = @event;
    //  if (handler == null) return;
    //  handler.BeginInvoke(sender, e, null, null);
    //}

    //public static void BeginInvoke<T>(EventHandler<T> @event, object sender, T e, AsyncCallback callback, object @obj) where T : EventArgs
    //{
    //  EventHandler<T> handler = @event;
    //  if (handler == null) return;
    //  handler.BeginInvoke(sender, e, callback, @obj);
    //}

    public static void BeginInvoke<T>(EventHandler<T> @event, object sender, T e) where T : EventArgs
    {
      EventHandler<T> handler = @event;
      if (handler == null)
      {
        return;
      }
      else
      {
        Delegate[] delArray = handler.GetInvocationList();

        foreach (Delegate del in delArray)
        {
          EventHandler<T> method = (EventHandler<T>)del;
          method.BeginInvoke(sender, e, null, null);
        }
      }
    }


    public static void BeginInvoke(EventHandler<EventArgs> @event, object sender, EventArgs e)
    {
      EventHandler<EventArgs> handler = @event;
      if (handler == null)
      {
        return;
      }
      else
      {
        Delegate[] delArray = handler.GetInvocationList();

        foreach (Delegate del in delArray)
        {
          EventHandler<EventArgs> method = (EventHandler<EventArgs>)del;
          method.BeginInvoke(sender, e, null, null);
        }
      }
    }

    public static void BeginInvoke(EventHandler @event, object sender, EventArgs e)
    {
      EventHandler handler = @event;
      if (handler == null)
      {
        return;
      }
      else
      {
        Delegate[] delArray = handler.GetInvocationList();

        foreach (Delegate del in delArray)
        {
          EventHandler method = (EventHandler)del;
          method.BeginInvoke(sender, e, null, null);
        }
      }
    }

    public static void BeginInvoke(MulticastDelegate @event, object sender, EventArgs e)
    {
      MulticastDelegate handler = @event;
      if (handler == null)
      {
        return;
      }
      else
      {
        Delegate[] delArray = handler.GetInvocationList();

        foreach (Delegate @delegate in delArray)
        {
          if (@delegate is EventHandler)
          {
            ((EventHandler)@delegate).BeginInvoke(sender, e, null, null);
          }
          else if (@delegate is MulticastDelegate)
          {
            MulticastDelegate method = (MulticastDelegate)@delegate;

            Type type = method.GetType();
            type.InvokeMember("BeginInvoke", System.Reflection.BindingFlags.InvokeMethod, null, method, new object[] { sender, e, null, null });
          }
        }
      }
    }

    public static void BeginInvoke(Action @event)
    {
      Action handler = @event;
      if (handler == null)
      {
        return;
      }
      else
      {
        Delegate[] delArray = handler.GetInvocationList();

        foreach (Delegate del in delArray)
        {
          Action method = (Action)del;
          method.BeginInvoke(null, null);
        }
      }
    }

    public static void BeginInvoke<T>(Action<T> @event, T e)
    {
      Action<T> handler = @event;
      if (handler == null)
      {
        return;
      }
      else
      {
        Delegate[] delArray = handler.GetInvocationList();

        foreach (Delegate del in delArray)
        {
          Action<T> method = (Action<T>)del;
          method.BeginInvoke(e, null, null);
        }
      }
    }
  }
}
