using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 解释器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            String instruction = "up move 5 and down run 10 and left move 5";
            InstructionHandler handler = new InstructionHandler();
            handler.handle(instruction);
            String outString;
            outString = handler.output();
            Console.WriteLine(outString);
            Console.ReadKey();
        }
    }


    //抽象表达式  
    abstract class AbstractNode
    {
        public abstract String interpret();
    }

    //And解释：非终结符表达式  
    class AndNode : AbstractNode
    {
        private AbstractNode left; //And的左表达式  
        private AbstractNode right; //And的右表达式  

        public AndNode(AbstractNode left, AbstractNode right)
        {
            this.left = left;
            this.right = right;
        }

        //And表达式解释操作  
        public override String interpret()
        {
            return left.interpret() + "再" + right.interpret();
        }
    }

    //简单句子解释：非终结符表达式  
    class SentenceNode : AbstractNode
    {
        private AbstractNode direction;
        private AbstractNode action;
        private AbstractNode distance;

        public SentenceNode(AbstractNode direction, AbstractNode action, AbstractNode distance)
        {
            this.direction = direction;
            this.action = action;
            this.distance = distance;
        }

        //简单句子的解释操作  
        public override String interpret()
        {
            return direction.interpret() + action.interpret() + distance.interpret();
        }
    }

    //方向解释：终结符表达式  
    class DirectionNode : AbstractNode
    {
        private String direction;

        public DirectionNode(String direction)
        {
            this.direction = direction;
        }

        //方向表达式的解释操作  
        public override String interpret()
        {
            if (direction.Equals("up", StringComparison.CurrentCultureIgnoreCase))
            {
                return "向上";
            }
            else if (direction.Equals("down", StringComparison.CurrentCultureIgnoreCase))
            {
                return "向下";
            }
            else if (direction.Equals("left", StringComparison.CurrentCultureIgnoreCase))
            {
                return "向左";
            }
            else if (direction.Equals("right", StringComparison.CurrentCultureIgnoreCase))
            {
                return "向右";
            }
            else
            {
                return "无效指令";
            }
        }
    }

    //动作解释：终结符表达式  
    class ActionNode : AbstractNode
    {
        private String action;

        public ActionNode(String action)
        {
            this.action = action;
        }

        //动作（移动方式）表达式的解释操作  
        public override String interpret()
        {
            if (action.Equals("move", StringComparison.CurrentCultureIgnoreCase))
            {
                return "移动";
            }
            else if (action.Equals("run", StringComparison.CurrentCultureIgnoreCase))
            {
                return "快速移动";
            }
            else
            {
                return "无效指令";
            }
        }
    }

    //距离解释：终结符表达式  
    class DistanceNode : AbstractNode
    {
        private String distance;

        public DistanceNode(String distance)
        {
            this.distance = distance;
        }

        //距离表达式的解释操作  
        public override String interpret()
        {
            return this.distance;
        }
    }

    //指令处理类：工具类  
    class InstructionHandler
    {
        private String instruction;
        private AbstractNode node;

        public void handle(String instruction)
        {
            AbstractNode left = null, right = null;
            AbstractNode direction = null, action = null, distance = null;
            Stack stack = new Stack(); //声明一个栈对象用于存储抽象语法树  
            String[] words = instruction.Split(' '); //以空格分隔指令字符串  
            for (int i = 0; i < words.Length; i++)
            {
                //本实例采用栈的方式来处理指令，如果遇到“and”，则将其后的三个单词作为三个终结符表达式连成一个简单句子SentenceNode作为“and”的右表达式，而将从栈顶弹出的表达式作为“and”的左表达式，最后将新的“and”表达式压入栈中。                  
                if (words[i].Equals("and", StringComparison.CurrentCultureIgnoreCase))
                {
                    left = (AbstractNode)stack.Pop(); //弹出栈顶表达式作为左表达式  
                    String word1 = words[++i];
                    direction = new DirectionNode(word1);
                    String word2 = words[++i];
                    action = new ActionNode(word2);
                    String word3 = words[++i];
                    distance = new DistanceNode(word3);
                    right = new SentenceNode(direction, action, distance); //右表达式  
                    stack.Push(new AndNode(left, right)); //将新表达式压入栈中  
                }
                //如果是从头开始进行解释，则将前三个单词组成一个简单句子SentenceNode并将该句子压入栈中  
                else
                {
                    String word1 = words[i];
                    direction = new DirectionNode(word1);
                    String word2 = words[++i];
                    action = new ActionNode(word2);
                    String word3 = words[++i];
                    distance = new DistanceNode(word3);
                    left = new SentenceNode(direction, action, distance);
                    stack.Push(left); //将新表达式压入栈中  
                }
            }
            this.node = (AbstractNode)stack.Pop(); //将全部表达式从栈中弹出  
        }

        public String output()
        {
            String result = node.interpret(); //解释表达式  
            return result;
        }
    }
}
