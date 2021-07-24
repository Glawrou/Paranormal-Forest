using UnityEngine;
using System.Collections;


public class CamWiggle : MonoBehaviour
{
    public AudioSource Step;
    public float targetTime = 0.2f; // Время на один шаг в секундах
    public float Smooth = 10; // Мягкость
    public float AmplitudeHeight = 0.1f; // Амлитуда покачивания вверх-вниз
    public float AmplitudeRot = 1.5f; // Амплитуда поворота  
    public bool tool = false;
    public bool SoudStep = false;

    private float Progress; // Прогресс
    private int PassedStep = 1; // Шаг
    private float DefCamPos = 0; // Изначальная позиция камеры
    private float DefCamRot = 0; // Изначальный поворот камеры
    private Transform MyTransform; // Наш трансформ


    void Start()
    {
        MyTransform = transform; // Ну, я где-то прочитал что так будет работать быстрей
        DefCamPos = MyTransform.localPosition.y; // Изначальная позиция камеры
        DefCamRot = MyTransform.localEulerAngles.z; // Изначальный поворот камеры
    }


    void Update()
    {
        float Pssd = Passed(); // Наш прогресс

        // Позиция в Vector3, к которой мы стримимся
        Vector3 GoalPos = new Vector3(MyTransform.localPosition.x, Pssd * AmplitudeHeight + DefCamPos, MyTransform.localPosition.z);
        // Интерполяция позиции (сглаживание)
        MyTransform.localPosition = Vector3.Lerp(MyTransform.localPosition, GoalPos, Time.deltaTime * Smooth);


        // Поворот в Vector3, к которому мы стримимся
        if (Mathf.Abs(Input.GetAxis("Horizontal")) == 1 && Mathf.Abs(Input.GetAxis("Vertical")) == 0)
        {
            Pssd = 0; // Только если мы не идем в бок
        }

        if (tool == true)
        MyTransform.localRotation = Quaternion.Euler(new Vector3(90f, 0, 0));
      
    }


    private float Passed()
    {

        // Если мы вообще никуда не двигаемся (право, лево, вперед, назад)
        // То возвращаем ноль
        if (Mathf.Abs(Input.GetAxis("Horizontal")) == 0 && Mathf.Abs(Input.GetAxis("Vertical")) == 0)
        {
            StopSound();
            PassedStep = 1; // Сбрасываем шаг
            return (Progress = 0); // Прогресс сводим к нулю и возвращаем его

          
        }     

        // Умножаем прогресс на шаг (PassedStep)
        // Если step = 1, то тогда значение не меняется.
        // А если step = -1, то тогда значение формулы становится отрицательным и мы начинаем вычитать из Progress
        Progress += (Time.deltaTime * (1f / targetTime)) * PassedStep;
        if (Mathf.Abs(Progress) >= 1)
        { // Если Progress больше или равно 1, или меньше или равно -1
            
            PassedStep *= -1; // Инвертируем шаг        
            
            PlaySound();
        }

        // Возвращаем прогресс, он у нас шляется от -1 до 1
        return Progress;
    }

    void PlaySound()
    {
  
        if(Step.isPlaying == false)
        {
            if (SoudStep == true)
                Step.Play();
        }
        
    }

    void StopSound()
    {
        if (SoudStep == true)
            Step.Stop();
    }
}