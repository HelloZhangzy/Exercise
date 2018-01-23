using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorBuilder ab =new AngelBuilder(); //反射生成具体建造者对象

            ActorController ac = new ActorController();
            Actor actor;
            actor = ac.construct(ab); //通过指挥者创建完整的建造者对象

            String type = actor.getType();
            Console.WriteLine(type + "的外观：");
            Console.WriteLine("性别：" + actor.getSex());
            Console.WriteLine("面容：" + actor.getFace());
            Console.WriteLine("服装：" + actor.getCostume());
            Console.WriteLine("发型：" + actor.getHairstyle());
            Console.ReadKey();
        }
    }

    class Actor
    {
        private String type; //角色类型
        private String sex; //性别
        private String face; //脸型
        private String costume; //服装
        private String hairstyle; //发型

        public void setType(String type)
        {
            this.type = type;
        }
        public void setSex(String sex)
        {
            this.sex = sex;
        }
        public void setFace(String face)
        {
            this.face = face;
        }
        public void setCostume(String costume)
        {
            this.costume = costume;
        }
        public void setHairstyle(String hairstyle)
        {
            this.hairstyle = hairstyle;
        }
        public String getType()
        {
            return (this.type);
        }
        public String getSex()
        {
            return (this.sex);
        }
        public String getFace()
        {
            return (this.face);
        }
        public String getCostume()
        {
            return (this.costume);
        }
        public String getHairstyle()
        {
            return (this.hairstyle);
        }
    }

    //角色建造器：抽象建造者
    abstract class ActorBuilder
    {
        protected Actor actor = new Actor();

        public abstract void buildType();
        public abstract void buildSex();
        public abstract void buildFace();
        public abstract void buildCostume();
        public abstract void buildHairstyle();

        //工厂方法，返回一个完整的游戏角色对象
        public Actor createActor()
        {
            return actor;
        }

        public virtual bool isBareheaded()
        {
            return false;
        }
    }

    //英雄角色建造器：具体建造者
    class HeroBuilder : ActorBuilder
    {
        public override void buildType()
        {
            actor.setType("英雄");
        }
        public override void buildSex()
        {
            actor.setSex("男");
        }
        public override void buildFace()
        {
            actor.setFace("英俊");
        }
        public override void buildCostume()
        {
            actor.setCostume("盔甲");
        }
        public override void buildHairstyle()
        {
            actor.setHairstyle("飘逸");
        }       
    }

    //天使角色建造器：具体建造者
    class AngelBuilder : ActorBuilder
    {
        public override void buildType()
        {
            actor.setType("天使");
        }
        public override void buildSex()
        {
            actor.setSex("女");
        }
        public override void buildFace()
        {
            actor.setFace("漂亮");
        }
        public override void buildCostume()
        {
            actor.setCostume("白裙");
        }
        public override void buildHairstyle()
        {
            actor.setHairstyle("披肩长发");
        }
        public override bool isBareheaded()
        {
            return true;
        }
    }

    //恶魔角色建造器：具体建造者
    class DevilBuilder : ActorBuilder
    {
        public override void buildType()
        {
            actor.setType("恶魔");
        }
        public override void buildSex()
        {
            actor.setSex("妖");
        }
        public override void buildFace()
        {
            actor.setFace("丑陋");
        }
        public override void buildCostume()
        {
            actor.setCostume("黑衣");
        }
        public override void buildHairstyle()
        {
            actor.setHairstyle("光头");
        }        
    }

    class ActorController
    {
        //逐步构建复杂产品对象
        public Actor construct(ActorBuilder ab)
        {
            Actor actor;

            ab.buildType();
            ab.buildSex();
            ab.buildFace();
            ab.buildCostume();

            if (!ab.isBareheaded())
            {
                ab.buildHairstyle();
            }
            
            actor = ab.createActor();
            return actor;
        }

    }

}
