[System.Serializable]
public class PlayerData
{
    public float health;
    public int score;
    public float[] position = new float[3];
    //otros datos

    public PlayerData(Player p)
    {
        health = p.life;
        score = p.score;
        position[0] = p.transform.position.x;
        position[1] = p.transform.position.y;
        position[2] = p.transform.position.z;
    }
}
