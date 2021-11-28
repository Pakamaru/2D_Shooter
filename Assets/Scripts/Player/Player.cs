public class Player : CombatUnit
{
    public Player(int hp, int dmg, float speed) : base(hp, dmg, speed)
    {
    }

    void Start()
    {
        Weapon = transform.Find("Body").Find("Gun").gameObject.GetComponent<Weapon>();
        Weapon.SetVars(this.gameObject, 10, 1, 5);
    }
}
