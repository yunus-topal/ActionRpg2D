using UnityEngine;

namespace Characters.Player {
    public class PlayerStatus : MonoBehaviour{
        private int _currHealth;
        private int _maxHealth;
        private int _gold;
        private int _level;
        private int _xp;

        public int CurrHealth {
            get => _currHealth;
            set => _currHealth = value;
        }

        public int MaxHealth {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        public int Gold {
            get => _gold;
            set => _gold = value;
        }

        public int Level {
            get => _level;
            set => _level = value;
        }

        public int Xp {
            get => _xp;
            set => _xp = value;
        }

        public void TakeDamage(int damage = 0) {
            _currHealth -= damage;
            if (_currHealth <= 0) {
                Time.timeScale = 0;
                Destroy(this);
            }
        }
    }
}
