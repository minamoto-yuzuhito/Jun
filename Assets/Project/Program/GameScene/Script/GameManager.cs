using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ToothController�N���X")]
    public ToothController toothController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�������ׂ��L�[��񎦂���
        toothController.PresentProblem();
    }
}
