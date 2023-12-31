using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

public class ChooseRootDNA : MonoBehaviour {
    public GameObject afterSelectAudioGO;
    public AudioSource clickAudio;

    public List<Image> _1P_option;
    public List<Image> _2P_option;
    public List<Sprite> optionSprites;

    private int _1P_nowOption;
    private int _2P_nowOption;

    private bool isFinishRootDNA = false;

    /*
    private void Awake()
    {
        GameObject gb = GlobalManager.LoadGlobalPrefabObject();
        if (gb != null)
        {
            Instantiate(gb);
        }
    }
    */
    private void Update() {
        //选择阶段
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (_1P_nowOption < _1P_option.Count) //如果1P还没选择完
            {
                //记载
                switch (_1P_nowOption) {
                    case 0:
                        GlobalManager._1P_rootDNA.Add('A');
                        break;

                    case 1:
                        GlobalManager._1P_rootDNA.Add('B');
                        break;

                    case 2:
                        GlobalManager._1P_rootDNA.Add('C');
                        break;

                    default:
                        break;
                }
                //更换UI图片
                _1P_option[_1P_nowOption].sprite = optionSprites[0];
                if (_1P_nowOption < _1P_option.Count - 1) {
                    _1P_option[_1P_nowOption + 1].sprite = optionSprites[_1P_nowOption + 1];
                }
                //计数器增加
                _1P_nowOption++;
                clickAudio.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (_1P_nowOption < _1P_option.Count) {
                //记载
                switch (_1P_nowOption) {
                    case 0:
                        GlobalManager._1P_rootDNA.Add('a');
                        break;

                    case 1:
                        GlobalManager._1P_rootDNA.Add('b');
                        break;

                    case 2:
                        GlobalManager._1P_rootDNA.Add('c');
                        break;

                    default:
                        break;
                }
                //更换UI图片
                _1P_option[_1P_nowOption].sprite = optionSprites[0];
                if (_1P_nowOption < _1P_option.Count - 1) {
                    _1P_option[_1P_nowOption + 1].sprite = optionSprites[_1P_nowOption + 1];
                }
                //计数器增加
                _1P_nowOption++;
                clickAudio.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            if (_2P_nowOption < _2P_option.Count) {
                //记载
                switch (_2P_nowOption) {
                    case 0:
                        GlobalManager._2P_rootDNA.Add('A');
                        break;

                    case 1:
                        GlobalManager._2P_rootDNA.Add('B');
                        break;

                    case 2:
                        GlobalManager._2P_rootDNA.Add('C');
                        break;

                    default:
                        break;
                }
                //更换UI图片
                _2P_option[_2P_nowOption].sprite = optionSprites[0];
                if (_2P_nowOption < _2P_option.Count - 1) {
                    _2P_option[_2P_nowOption + 1].sprite = optionSprites[_2P_nowOption + 1];
                }
                //计数器增加
                _2P_nowOption++;
                clickAudio.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)) {
            if (_2P_nowOption < _2P_option.Count) {
                //记载
                switch (_2P_nowOption) {
                    case 0:
                        GlobalManager._2P_rootDNA.Add('a');
                        break;

                    case 1:
                        GlobalManager._2P_rootDNA.Add('b');
                        break;

                    case 2:
                        GlobalManager._2P_rootDNA.Add('c');
                        break;

                    default:
                        break;
                }
                //更换UI图片
                _2P_option[_2P_nowOption].sprite = optionSprites[0];
                if (_2P_nowOption < _2P_option.Count - 1) {
                    _2P_option[_2P_nowOption + 1].sprite = optionSprites[_2P_nowOption + 1];
                }
                //计数器增加
                _2P_nowOption++;
                clickAudio.Play();
            }
        }

        //选择完毕
        if (_1P_nowOption == _1P_option.Count && _2P_nowOption == _2P_option.Count && !isFinishRootDNA) {
            EventCenter.GetInstance().EventTrigger(EventTypes.FinishChooseRootDNA); //分发选择根基因完成事件
            //根据双方根基因，计算目标基因
            for (int i = 0; i < GlobalManager._1P_rootDNA.Count; i++) {
                GlobalManager.rootDNA.Add(GlobalManager._1P_rootDNA[i]);
                GlobalManager.rootDNA.Add(GlobalManager._2P_rootDNA[i]);
            }
            isFinishRootDNA = true;

            StartCoroutine(LagToNextScene());
        }
    }

    IEnumerator LagToNextScene() {
        yield return new WaitForSeconds(0.5f);
        var panel = transform.GetChild(0);
        var resultTextParentTrans = panel.Find("Result");
        resultTextParentTrans.gameObject.SetActive(true);
        for (int i = 0; i < GlobalManager._1P_rootDNA.Count * 2; i++) {
            resultTextParentTrans.GetChild(i).GetComponent<TextMeshProUGUI>().text = GlobalManager.rootDNA[i].ToString();
        }
        resultTextParentTrans.gameObject.SetActive(false);
        afterSelectAudioGO.SetActive(true);
        StartCoroutine(SetAlphaSmoothly());

        GenerateGameObject();

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("ChooseFightDNA");
    }

    void GenerateGameObject() {
        var target = ResMgr.GetInstance().Load<GameObject>("Target");
        target.transform.position = Vector3.down * 1.5f;
        target.transform.localScale = Vector3.one * 3;
    }

    IEnumerator SetAlphaSmoothly() {
        var image = transform.GetChild(0).GetComponent<Image>();
        while (image.color.a > 0) {
            var color = image.color;
            color.a -= 2f;
            image.color = color;
            yield return new WaitForSecondsRealtime(0.02f);
            // 0.02 * 50 = 1；
        }
    }
}