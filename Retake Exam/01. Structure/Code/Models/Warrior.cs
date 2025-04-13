using LegendsOfValor_TheGuildTrials.Models.Contracts;

namespace Models
{
    public class Warrior : Hero
    {
        public Warrior(string name, string runeMark)
            : base(name, runeMark, 60, 0, 100)
        {
        }

        public override void Train()
        {
            Power += 30;
            Stamina += 10;
        }
    }
} 