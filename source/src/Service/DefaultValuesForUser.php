<?php

namespace App\Service;


use App\Entity\User;

class DefaultValuesForUser
{

    /**
     * getting initial user only with default data( without login, pass...)
     * @return User
    */
    public function getUserWithDefaultData()
    {
        return $this->initDefaultValues();
    }

    /**
     * Init default data for new user
    */
    protected function initDefaultValues()
    {
        $user = new User();
        $dataTime = new \DateTime("now");

        $user->setKarma(100);
        $user->setCreateDate($dataTime);
        $user->setUpdateDate($dataTime);

        return $user;
    }
}