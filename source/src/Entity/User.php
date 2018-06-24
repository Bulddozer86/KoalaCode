<?php


namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\Security\Core\User\AdvancedUserInterface;
use Symfony\Component\Security\Core\User\UserInterface;
use Symfony\Bridge\Doctrine\Validator\Constraints\UniqueEntity;
use Symfony\Component\Validator\Constraints as Assert;


/**
 * @ORM\Entity(repositoryClass="App\Repository\UserRepository")
 * @ORM\Table(name="user")
 */
class User implements UserInterface, \Serializable, AdvancedUserInterface
{
    /**
     * @var int
     *
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(type="integer")
     */
    private $id;

    /**
     * @ORM\Column(type="string", length=100, name="login")
     */
    private $login;

    /**
     * @ORM\Column(type="string", length=255, name="password")
     */
    private $password;

    /**
     * @ORM\Column(type="string", length=255, unique=true, name="email")
     * @Assert\Email()
     */
    private $email;

    /**
     * @ORM\Column(type="string", length=150, name="first_name")
     */
    private $firstName;

    /**
     * @ORM\Column(type="string", length=150, name="last_name")
     */
    private $lastName;

    /**
     * @ORM\Column(type="text", name="description")
     */
    private $description;

    /**
     * @ORM\Column(type="integer", name="karma")
     */
    private $karma;

    /**
     * @ORM\Column(type="datetime", name="create_date")
     */
    private $createDate;

    /**
     * @ORM\Column(type="integer", name="delete_by_id", nullable=true)
     */
    private $deleteById;

    /**
     * @ORM\Column(type="integer", name="delete_by", nullable=true)
     */
    private $deleteBy;

    /**
     * @ORM\Column(type="datetime", name="delete_data", nullable=true)
     */
    private $deleteData;

    /**
     * @ORM\Column(type="integer", name="update_by_id", nullable=true)
     */
    private $updateById;

    /**
     * @ORM\Column(type="integer", name="update_by",nullable=true)
     */
    private $updateBy;

    /**
     * @ORM\Column(type="datetime", name="update_date", nullable=true)
     */
    private $updateDate;

    /**
     * @ORM\Column(type="integer", name="banned_by_id", nullable=true)
     */
    private $bannedById;

    /**
     * @ORM\Column(type="integer", name="banned_by", nullable=true)
     */
    private $bannedBy;

    /**
     * @ORM\Column(type="datetime", name="banned_date", nullable=true)
     */
    private $bannedDate;

    /**
     * @ORM\Column(name="is_active", type="boolean", nullable=true)
     */
    private $isActive;

    /**
     * @ORM\Column(type="integer", name="banned_for", nullable=true)
     */
    private $bannedFor;

    /**
     * Initial object
    */
    public function __construct()
    {
        $this->isActive = true;
        // may not be needed, see section on salt below
        // $this->salt = md5(uniqid('', true));
    }

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getLogin(): ?string
    {
        return $this->login;
    }

    public function setLogin(string $login): self
    {
        $this->login = $login;

        return $this;
    }

    public function getPassword(): ?string
    {
        return $this->password;
    }

    public function setPassword(string $password): self
    {
        $this->password = $password;

        return $this;
    }

    public function getEmail(): ?string
    {
        return $this->email;
    }

    public function setEmail(string $email): self
    {
        $this->email = $email;

        return $this;
    }

    public function getFirstName(): ?string
    {
        return $this->firstName;
    }

    public function setFirstName(string $firstName): self
    {
        $this->firstName = $firstName;

        return $this;
    }

    public function getLastName(): ?string
    {
        return $this->lastName;
    }

    public function setLastName(string $lastName): self
    {
        $this->lastName = $lastName;

        return $this;
    }

    public function getDescription(): ?string
    {
        return $this->description;
    }

    public function setDescription(string $description): self
    {
        $this->description = $description;

        return $this;
    }

    public function getKarma(): ?int
    {
        return $this->karma;
    }

    public function setKarma(int $karma): self
    {
        $this->karma = $karma;

        return $this;
    }

    public function getCreateDate(): ?\DateTimeInterface
    {
        return $this->createDate;
    }

    public function setCreateDate(\DateTimeInterface $createDate): self
    {
        $this->createDate = $createDate;

        return $this;
    }

    public function getDeleteById(): ?int
    {
        return $this->deleteById;
    }

    public function setDeleteById(int $deleteById): self
    {
        $this->deleteById = $deleteById;

        return $this;
    }

    public function getDeleteBy(): ?int
    {
        return $this->deleteBy;
    }

    public function setDeleteBy(int $deleteBy): self
    {
        $this->deleteBy = $deleteBy;

        return $this;
    }

    public function getDeleteData(): ?\DateTimeInterface
    {
        return $this->deleteData;
    }

    public function setDeleteData(\DateTimeInterface $deleteData): self
    {
        $this->deleteData = $deleteData;

        return $this;
    }

    public function getUpdateById(): ?int
    {
        return $this->updateById;
    }

    public function setUpdateById(int $updateById): self
    {
        $this->updateById = $updateById;

        return $this;
    }

    public function getUpdateBy(): ?int
    {
        return $this->updateBy;
    }

    public function setUpdateBy(int $updateBy): self
    {
        $this->updateBy = $updateBy;

        return $this;
    }

    public function getUpdateDate(): ?\DateTimeInterface
    {
        return $this->updateDate;
    }

    public function setUpdateDate(\DateTimeInterface $updateDate): self
    {
        $this->updateDate = $updateDate;

        return $this;
    }

    public function getBannedById(): ?int
    {
        return $this->bannedById;
    }

    public function setBannedById(int $bannedById): self
    {
        $this->bannedById = $bannedById;

        return $this;
    }

    public function getBannedBy(): ?int
    {
        return $this->bannedBy;
    }

    public function setBannedBy(int $bannedBy): self
    {
        $this->bannedBy = $bannedBy;

        return $this;
    }

    public function getBannedDate(): ?\DateTimeInterface
    {
        return $this->bannedDate;
    }

    public function setBannedDate(\DateTimeInterface $bannedDate): self
    {
        $this->bannedDate = $bannedDate;

        return $this;
    }

    public function getBannedFor(): ?int
    {
        return $this->bannedFor;
    }

    public function setBannedFor(int $bannedFor): self
    {
        $this->bannedFor = $bannedFor;

        return $this;
    }

    /**
     * Returns the roles granted to the user.
     *
     * <code>
     * public function getRoles()
     * {
     *     return array('ROLE_USER');
     * }
     * </code>
     *
     * Alternatively, the roles might be stored on a ``roles`` property,
     * and populated in any number of different ways when the user object
     * is created.
     *
     * @return (Role|string)[] The user roles
     */
    public function getRoles()
    {
        return ['ROLE_USER'];
    }

    /**
     * Returns the salt that was originally used to encode the password.
     *
     * This can return null if the password was not encoded using a salt.
     *
     * @return string|null The salt
     */
    public function getSalt()
    {
        // TODO: Implement getSalt() method.
        return null;
    }

    /**
     * Returns the username used to authenticate the user.
     *
     * @return string The username
     */
    public function getUsername()
    {
        return $this->login;
    }

    /**
     * Removes sensitive data from the user.
     *
     * This is important if, at any given point, sensitive information like
     * the plain-text password is stored on this object.
     */
    public function eraseCredentials()
    {
        // TODO: Implement eraseCredentials() method.
    }

    /**
     * String representation of object
     * @link http://php.net/manual/en/serializable.serialize.php
     * @return string the string representation of the object or null
     * @since 5.1.0
     */
    /** @see \Serializable::serialize() */
    public function serialize()
    {
        return serialize([
            $this->id,
            $this->login,
            $this->password,
            $this->isActive
            // see section on salt below
            // $this->salt,
        ]);
    }

    /**
     * Constructs the object
     * @link http://php.net/manual/en/serializable.unserialize.php
     * @param string $serialized <p>
     * The string representation of the object.
     * </p>
     * @return void
     * @since 5.1.0
     */
    public function unserialize($serialized)
    {
        list (
            $this->id,
            $this->login,
            $this->password,
            $this->isActive
            // see section on salt below
            // $this->salt
            ) = unserialize($serialized, ['allowed_classes' => false]);
    }

    /**
     * Checks whether the user's account has expired.
     *
     * Internally, if this method returns false, the authentication system
     * will throw an AccountExpiredException and prevent login.
     *
     * @return bool true if the user's account is non expired, false otherwise
     *
     * @see AccountExpiredException
     */
    public function isAccountNonExpired()
    {
        return true;
    }

    /**
     * Checks whether the user is locked.
     *
     * Internally, if this method returns false, the authentication system
     * will throw a LockedException and prevent login.
     *
     * @return bool true if the user is not locked, false otherwise
     *
     * @see LockedException
     */
    public function isAccountNonLocked()
    {
        return true;
    }

    /**
     * Checks whether the user's credentials (password) has expired.
     *
     * Internally, if this method returns false, the authentication system
     * will throw a CredentialsExpiredException and prevent login.
     *
     * @return bool true if the user's credentials are non expired, false otherwise
     *
     * @see CredentialsExpiredException
     */
    public function isCredentialsNonExpired()
    {
        return true;
    }

    /**
     * Checks whether the user is enabled.
     *
     * Internally, if this method returns false, the authentication system
     * will throw a DisabledException and prevent login.
     *
     * @return bool true if the user is enabled, false otherwise
     *
     * @see DisabledException
     */
    public function isEnabled()
    {
        return $this->isActive;
    }
}