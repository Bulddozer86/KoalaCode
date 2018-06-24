<?php

namespace App\Controller;

use App\Service\DefaultValuesForUser;
use Symfony\Component\Routing\Annotation\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use App\Form\UserType;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Security\Core\Encoder\UserPasswordEncoderInterface;
use Symfony\Component\Security\Http\Authentication\AuthenticationUtils;

class AuthorizationController extends Controller
{
    /**
     * @Route("/login", name="login")
     * @param AuthenticationUtils $authenticationUtils
     * @return Response
     */
    public function loginAction(AuthenticationUtils $authenticationUtils)
    {
        $errors = $authenticationUtils->getLastAuthenticationError();
        $lastUserName = $authenticationUtils->getLastUsername();

        return $this->render('authorization/login.html.twig', [
            'errors' => $errors,
            'username' => $lastUserName
        ]);
    }

    /**
     * @Route("/logout", name="logout")
     */
    public function logoutAction(){}

    /**
     * @Route("/registration", name="registration")
     * @param Request $request
     * @param UserPasswordEncoderInterface $encoder
     * @param DefaultValuesForUser $defaultValuesForUser
     * @return Response
     */
    public function registrationAction(
        Request $request,
        UserPasswordEncoderInterface $encoder,
        DefaultValuesForUser $defaultValuesForUser
    )
    {
        $em   = $this->getDoctrine()->getManager();
        $user = $defaultValuesForUser->getUserWithDefaultData();
        $form = $this->createForm(UserType::class, $user);

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            $user->setPassword($encoder->encodePassword($user, $user->getPassword()));

            $em->persist($user);
            $em->flush();

            return $this->redirect('/login');
        }

        return $this->render('authorization/registration.html.twig', [
            'form' => $form->createView()
        ]);
    }
}
