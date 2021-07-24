using UnityEngine;
using System.Collections;


public class CamWiggle : MonoBehaviour
{
    public AudioSource Step;
    public float targetTime = 0.2f; // ����� �� ���� ��� � ��������
    public float Smooth = 10; // ��������
    public float AmplitudeHeight = 0.1f; // �������� ����������� �����-����
    public float AmplitudeRot = 1.5f; // ��������� ��������  
    public bool tool = false;
    public bool SoudStep = false;

    private float Progress; // ��������
    private int PassedStep = 1; // ���
    private float DefCamPos = 0; // ����������� ������� ������
    private float DefCamRot = 0; // ����������� ������� ������
    private Transform MyTransform; // ��� ���������


    void Start()
    {
        MyTransform = transform; // ��, � ���-�� �������� ��� ��� ����� �������� �������
        DefCamPos = MyTransform.localPosition.y; // ����������� ������� ������
        DefCamRot = MyTransform.localEulerAngles.z; // ����������� ������� ������
    }


    void Update()
    {
        float Pssd = Passed(); // ��� ��������

        // ������� � Vector3, � ������� �� ���������
        Vector3 GoalPos = new Vector3(MyTransform.localPosition.x, Pssd * AmplitudeHeight + DefCamPos, MyTransform.localPosition.z);
        // ������������ ������� (�����������)
        MyTransform.localPosition = Vector3.Lerp(MyTransform.localPosition, GoalPos, Time.deltaTime * Smooth);


        // ������� � Vector3, � �������� �� ���������
        if (Mathf.Abs(Input.GetAxis("Horizontal")) == 1 && Mathf.Abs(Input.GetAxis("Vertical")) == 0)
        {
            Pssd = 0; // ������ ���� �� �� ���� � ���
        }

        if (tool == true)
        MyTransform.localRotation = Quaternion.Euler(new Vector3(90f, 0, 0));
      
    }


    private float Passed()
    {

        // ���� �� ������ ������ �� ��������� (�����, ����, ������, �����)
        // �� ���������� ����
        if (Mathf.Abs(Input.GetAxis("Horizontal")) == 0 && Mathf.Abs(Input.GetAxis("Vertical")) == 0)
        {
            StopSound();
            PassedStep = 1; // ���������� ���
            return (Progress = 0); // �������� ������ � ���� � ���������� ���

          
        }     

        // �������� �������� �� ��� (PassedStep)
        // ���� step = 1, �� ����� �������� �� ��������.
        // � ���� step = -1, �� ����� �������� ������� ���������� ������������� � �� �������� �������� �� Progress
        Progress += (Time.deltaTime * (1f / targetTime)) * PassedStep;
        if (Mathf.Abs(Progress) >= 1)
        { // ���� Progress ������ ��� ����� 1, ��� ������ ��� ����� -1
            
            PassedStep *= -1; // ����������� ���        
            
            PlaySound();
        }

        // ���������� ��������, �� � ��� ������� �� -1 �� 1
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