using System.Collections;

using System.Collections.Generic;

using UnityEngine;

 

public class FootstepsSoundController : MonoBehaviour

{

    public AudioClip FootstepsSound;

     public AudioClip JumpSound;

    public AudioClip LandingSound;

     private AudioSource audioSource;

    private CharacterController cController;

     private bool wasGrounded = false;

     void Start()

    {

        //getcomponent очень требователен к ресурсам компьютера, поэтому мы выполняем его один раз, “сохраняем ссылки” на компоненты

        audioSource = GetComponent<AudioSource>();

        cController = GetComponent<CharacterController>();

           

    }

     void FixedUpdate()

    {

         if (cController.isGrounded) //персонаж на земле

        {

             if (cController.velocity.sqrMagnitude > 0f) //персонаж двигается, используется квадратичная магнитуда,

//т.к. это операция менее требовательна к ресурсам, и нам не нужна точная скорость – нам нужен сам факт передвижения

            {

                if (!audioSource.isPlaying) { //проигрываем новый звук, только если сейчас никакой звук не играет

                    audioSource.clip = FootstepsSound;

                    audioSource.Play();

                }

                  

            }

else //персонаж НЕ двигается

            {

                if (audioSource.clip != JumpSound && audioSource.clip != LandingSound) //если аудиоклип в AudioSorce это не клип прыжка и не клип приземление

                    if (audioSource.isPlaying)  //если звук проигрывается

                        audioSource.Stop();  //выключаем проигрывание звуков

            }

 

            if (cController.isGrounded != wasGrounded) //проигрываем звук, если раньше персонаж был на земле, а теперь в воздухе

            {

                audioSource.Stop();

                audioSource.clip = LandingSound;

                audioSource.Play();

            }

 

            wasGrounded = true; //запоминаем прошлое состояние персонажа – в данном случае персонаж на земле

        }

        else //персонаж НE на земле

{

  if (audioSource.clip != JumpSound && audioSource.clip != LandingSound) //если аудиоклип в AudioSorce это не клип прыжка и не клип приземление

            {

                if (audioSource.isPlaying) //если звук проигрывается

                { 

                    audioSource.Stop();  //выключаем проигрывание звуков

                }

            }

  

            if (cController.isGrounded != wasGrounded) //проигрываем звук, если раньше персонаж был в воздухе, а теперь на земле

            {

                audioSource.Stop();

                audioSource.clip = JumpSound;

                audioSource.Play();

            }

            wasGrounded = false; //запоминаем прошлое состояние персонажа – в данном случае персонаж в воздухе 

        }

       

    }

}