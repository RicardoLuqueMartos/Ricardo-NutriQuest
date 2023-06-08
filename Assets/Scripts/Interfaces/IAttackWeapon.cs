public interface IAttackWeapon
{
    void Fire(CharacterController _characterController);
    void ByPlayer(CharacterController _characterController);

    void Unlock();

    void Lock();


}