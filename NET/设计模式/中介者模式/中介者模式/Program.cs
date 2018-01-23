using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中介者模式
{
    public abstract class PlayerControllerButton
    {
        protected PlayerController _controller;
        public bool Enable { get; set; }

        public PlayerControllerButton(PlayerController controller)
        {
            _controller = controller;
        }

        public virtual void Click()
        {
            _controller.ClickButton(this);
        }
    }

    public class StartButton : PlayerControllerButton
    {
        public StartButton(PlayerController controller)
            : base(controller)
        {
            controller.Register(this);
        }
    }

    public class StopButton : PlayerControllerButton
    {
        public StopButton(PlayerController controller)
            : base(controller)
        {
            controller.Register(this);
        }
    }

    public class PauseButton : PlayerControllerButton
    {
        public PauseButton(PlayerController controller)
            : base(controller)
        {
            controller.Register(this);
        }
    }

    public class PlayerController
    {
        private StartButton _startButton;
        private StopButton _stopButton;
        private PauseButton _pauseButton;

        public PlayerController()
        {
        }

        public void Register(PlayerControllerButton button)
        {
            if (button.GetType().ToString() == "DesignPattern.Mediator.StartButton")
            {
                _startButton = button as StartButton;
            }
            else if (button.GetType().ToString() == "DesignPattern.Mediator.StopButton")
            {
                _stopButton = button as StopButton;
            }
            else if (button.GetType().ToString() == "DesignPattern.Mediator.PauseButton")
            {
                _pauseButton = button as PauseButton;
            }
        }

        public void ClickButton(PlayerControllerButton button)
        {
            if (button == _startButton)
            {
                _startButton.Enable = true;
                _stopButton.Enable = false;
                _pauseButton.Enable = false;
            }
            else if (button == _stopButton)
            {
                _startButton.Enable = false;
                _stopButton.Enable = true;
                _pauseButton.Enable = false;
            }
            else if (button == _pauseButton)
            {
                _startButton.Enable = false;
                _stopButton.Enable = false;
                _pauseButton.Enable = true;
            }
        }

        public void DisplayButtonState()
        {
            Console.WriteLine("StartButton is {0}, StopButton is {1}, PauseButton is {2}", _startButton.Enable, _stopButton.Enable, _pauseButton.Enable);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
