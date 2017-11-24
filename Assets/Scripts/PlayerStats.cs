namespace Assets.Scripts
{
    public class PlayerStats
    {
        int kills;
        int damageDone;
        int damageTaken;
        int deaths;

        public PlayerStats()
        {
            this.kills = 0;
            this.damageDone = 0;
            this.damageTaken = 0;
            this.deaths = 0;
        }

        public void incrementKills()
        {
            this.kills++;
        }

        public void incrementDeaths()
        {
            this.deaths++;
        }

        public int getKills()
        {
            return this.kills;
        }

        public int getDeaths()
        {
            return this.deaths;
        }
    }

}
