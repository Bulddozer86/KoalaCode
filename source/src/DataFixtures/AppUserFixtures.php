<?php
namespace App\DataFixtures;


use Doctrine\Bundle\FixturesBundle\Fixture;
use Doctrine\Common\Persistence\ObjectManager;
use Symfony\Component\DependencyInjection\ContainerInterface;
use Symfony\Component\Security\Core\Encoder\UserPasswordEncoderInterface;

class AppUserFixtures extends Fixture
{
    /**
     * @var UserPasswordEncoderInterface
    */
    private $encoder;

    /**
     * @var ContainerInterface
    */
    private $container;

    public function __construct(
        UserPasswordEncoderInterface $encoder,
        ContainerInterface $container = null
    )
    {
        $this->encoder = $encoder;
        $this->container = $container;
    }

    /**
     * Load data fixtures with the passed EntityManager
     *
     * @param ObjectManager $manager
     */
    public function load(ObjectManager $manager)
    {
        for ($i = 1; $i <= 3; $i++) {
            $user = $this->container
                ->get('user.init_default_data')
                ->getUserWithDefaultData();

            $var = 'user' . $i;
            $password = $this->encoder
                ->encodePassword($user, $var . $i);

            $user->setLogin($var);
            $user->setPassword($password);
            $user->setFirstName($var . '_firstName');
            $user->setLastName($var . '_lastName');
            $user->setEmail($var . '@mail.com');

            $manager->persist($user);
            $manager->flush();
        }
    }
}