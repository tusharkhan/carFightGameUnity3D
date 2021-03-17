namespace UnityStandardAssets.Vehicles.Car
{
    public class HealthHelper 
    {
        public float currentHealth;
        public float maxHealth;

        public float damageAmount;

        public void getDamage()
        {
            setCurrentHealth( getCurentHealth() - getDamageAmount());
        }

        public void setMaxHealth(float amount)
        {
            maxHealth = amount;
        }


        public float getMaxHealth()
        {
            return maxHealth;
        }


        public void setCurrentHealth(float amount)
        {
            currentHealth = amount;
        }


        public float getCurentHealth()
        {
            return currentHealth;
        }


        public void setDamageAmount(float amount)
        {
            damageAmount = amount;
        }

        public float getDamageAmount()
        {
            return damageAmount;
        }
    }
}