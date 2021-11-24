//====================Copyright statement:AppsTools===================//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Perfect_RPG_MMO_3D_Effect_VFX_Pack_Demo : MonoBehaviour
{
    string ss = "FX_MST_003_Arrow&FX_MST_B011_SDJ_Arrow_02&FX_MST_B011_SDJ_Hit_01&FX_MST_B011_SDJ_Hit_03&Fx_MST_052_Arrow_Attack_01&Fx_MST_052_Arrow_Attack_01_1&Fx_Skill_KZ_Attact_01&Fx_Skill_KZ_Attact_02&Fx_Skill_KZ_Attact_03&Fx_Skill_KZ_CF_1&Fx_Skill_KZ_CF_2&Fx_Skill_KZ_FZ&Fx_Skill_KZ_JRFB_2&Fx_Skill_KZ_LD&Fx_Skill_KZ_LD_1&Fx_Skill_KZ_LM&Fx_Skill_KZ_PDNH&Fx_Skill_KZ_SL&Fx_Skill_KZ_YR&Fx_Skill_KZ_ZDNH&Fx_Skill_KZ_ZS&Fx_Skill_KZ_ZSDJ&Fx_Skill_KZ_ZS_1&Fx_skill_B024_SXBK&FX_MST_B011_DZSF_01&FX_MST_B011_FZBH_01&FX_MST_B011_HSWQ&FX_MST_B011_SZZY_01&FX_MST_B011_YSEC_02&FX_STA_JiNu&FX_STA_Skeleton&Fx_MST_006_Sewage&Fx_MST_B028_SSBL&Fx_MST_B028_SSBL_BUFF&Fx_STA_AMTF1&Fx_STA_AYM_AYXT&Fx_STA_AYM_AYXT_L&Fx_STA_AYM_AYXT_R&Fx_STA_AYM_LLSG&Fx_STA_AYM_LLSG_Sj&Fx_STA_AYM_ZZ1&Fx_STA_AYM_ZZ2&Fx_STA_Aim&Fx_STA_AttackMonster&Fx_STA_BFTF1&Fx_STA_CM&Fx_STA_Counter_01&Fx_STA_Counter_02&Fx_STA_DefenseMonster&Fx_STA_Hit_Bleed_01&Fx_STA_Ice_01&Fx_STA_Ice_02&Fx_STA_KJ&Fx_STA_KZ_FZ&Fx_STA_KZ_LM&Fx_STA_QTQS&Fx_STA_SlowDown04&Fx_STA_SlowDown_01&Fx_STA_SlowDown_02&Fx_STA_SlowDown_03&Fx_STA_Staring_02&Fx_STA_Stop_01&Fx_STA_TreatmentMonster&Fx_STA_YJ_FYJD&Fx_STA_YJ_SL&Fx_STA_MY&Fx_Skill_AYM_AYHL&Fx_Skill_AYM_AYHL_1&Fx_Skill_AYM_AYXT_2&Fx_Skill_AYM_AYXT_3&Fx_Skill_AYM_Attact_01&Fx_Skill_AYM_Attact_01_1&Fx_Skill_AYM_JSBT&Fx_Skill_AYM_JSBT_1&Fx_Skill_AYM_JSBT_2&Fx_Skill_AYM_LHZZ&Fx_Skill_AYM_LHZZ_SJ&Fx_Skill_AYM_LLSG_2&Fx_Skill_AYM_LLSG_2_1&Fx_Skill_AYM_LLSG_3&Fx_Skill_AYM_MY&Fx_Skill_AYM_SJ&Fx_Skill_AYM_XXGYB_2&Fx_Skill_AYM_XXGYB_2SJ&Fx_Skill_AYM_XXGYB_3&Fx_Skill_AYM_XXGYB_3SJ&Fx_Skill_AYM_XXGZC_2&Fx_Skill_AYM_XXGZC_3&Fx_Skill_AYM_XXGZC_3_1&Fx_Skill_SSM_CM_2&Fx_Skill_SSM_CM_2_1&Fx_Skill_SSM_CM_3&FX_MST_B011_HZLY_01&FX_MST_B011_HZLY_01_1&FX_MST_B011_HZLY_02&FX_MST_B011_HZLY_02_1&FX_STA_B026_JBZZP&Fx_STA_HFTF1&Fx_Skill_HF_Attact01_1&Fx_Skill_HF_Attact01_2&Fx_Skill_HF_DHQ_1&Fx_Skill_HF_DHQ_1_1&Fx_Skill_HF_DHQ_2&Fx_Skill_HF_DHQ_3&Fx_Skill_HF_JYP_1&Fx_Skill_HF_JYP_2&Fx_Skill_HF_LHJX_1&Fx_Skill_HF_LHJX_2&Fx_Skill_HF_LXS&Fx_Skill_HF_LYCJ_1&Fx_Skill_HF_LYCJ_2&Fx_Skill_HF_MX&Fx_Skill_HF_RS_1&Fx_Skill_HF_RS_2&Fx_Skill_HF_RYHJ_1&Fx_Skill_HF_RYHJ_2&Fx_Skill_HF_RYHJ_3&Fx_Skill_HF_SG&Fx_MST_B028_Disappear&Fx_MST_B028_YDNDHB&Fx_MST_B028_YDNDHB_01&Fx_MST_B028_YDNDJT&Fx_MST_B029_Create&Fx_MST_B029_HMZY&Fx_MST_B029_LHSL&Fx_MST_B029_LHSL_01&Fx_MST_B029_LHSL_02&Fx_MST_B029_QXNH&Fx_MST_B029_QXNH_D&Fx_MST_B029_SG&Fx_MST_B029_SNSF&Fx_MST_B029_SSLL&Fx_MST_BO29_010_Skill_Recover&Fx_STA_SMTF1&Fx_STA_SSM_SJ&Fx_STA_SSM_TJSB_L&Fx_STA_SSM_TJSB_R&Fx_STA_SSM_ZYSZ&Fx_STA_SYSY&Fx_Skill_MS_Attact_01&Fx_Skill_MS_Attact_01_1&Fx_Skill_MS_SSXX&Fx_Skill_MS_SSZH_2&Fx_Skill_MS_SSZH_2_1&Fx_Skill_MS_SSZH_3&Fx_Skill_MS_SSZH_3_1&Fx_Skill_MS_XLJX&Fx_Skill_MS_XLJX_a&Fx_Skill_SSM_Attact_01&Fx_Skill_SSM_Attact_01_1&Fx_Skill_SSM_JH_2_1&Fx_Skill_SSM_JH_3&Fx_Skill_SSM_JH_SJ&Fx_Skill_SSM_QTQS_2&Fx_Skill_SSM_QTQS_2_1&Fx_Skill_SSM_QTQS_3&Fx_Skill_SSM_SBS&Fx_Skill_SSM_SBS_1&Fx_Skill_SSM_SGMY&Fx_Skill_SSM_SG_2&Fx_Skill_SSM_SG_3&Fx_Skill_SSM_SG_3_1&Fx_Skill_SSM_SSZMS_2&Fx_Skill_SSM_SSZMS_2_1&Fx_Skill_SSM_SSZMS_3&Fx_Skill_SSM_SSZY_2&Fx_Skill_SSM_SSZY_2_1&Fx_Skill_SSM_SSZY_3&Fx_Skill_SSM_SSZY_3_1&Fx_Skill_SSM_SYSY_2&Fx_Skill_SSM_SYSY_3&Fx_Skill_SSM_TJSB&Fx_Skill_SSM_ZYSR&Fx_Skill_SSM_ZYSZ&Fx_Skill_SSM_ZYSZ_2&Fx_Skill_SSM_ZYSZ_3&Fx_Fx_Skill_BF_BSXX&Fx_STA_Soul&Fx_Skill_1001&Fx_Skill_BF_Attack_01&Fx_Skill_BF_Attack_01_1&Fx_Skill_BF_BDLY_1&Fx_Skill_BF_BDLY_2&Fx_Skill_BF_BDLY_3&Fx_Skill_BF_BFX_1&Fx_Skill_BF_BFX_2&Fx_Skill_BF_BFX_2_1&Fx_Skill_BF_BQS_2&Fx_Skill_BF_BQS_3&Fx_Skill_BF_BQS_3_1&Fx_Skill_BF_BQS_3_2&Fx_Skill_BF_BSJ_1&Fx_Skill_BF_BSJ_2&Fx_Skill_BF_BSXX&Fx_Skill_BF_BXS_2&Fx_Skill_BF_BXS_3&Fx_Skill_BF_BXS_3_1&Fx_Skill_BF_BXS_SG&Fx_Skill_BF_DLRGH&Fx_Skill_BF_HBJ_1&Fx_Skill_BF_HBJ_2&Fx_Skill_BF_HBPZ&Fx_Skill_BF_HBPZ_1&Fx_Skill_BF_HBPZ_2&Fx_Skill_BF_HBPZ_3&Fx_Skill_BF_HBZD_1&Fx_Skill_BF_HBZD_2&Fx_Skill_BF_HBZD_3&Fx_Skill_BF_HBZD_4&Fx_Skill_BF_HBZD_5&Fx_Skill_BF_SG&Fx_Skill_BF_SXS&Fx_Skill_FS_ASCJ&Fx_Skill_FS_ASCJ_1&Fx_Skill_FS_ASFD_2&Fx_Skill_FS_ASFD_3&Fx_Skill_FS_ASFD_3_1&Fx_Skill_FS_Attack01&Fx_Skill_FS_Attack01_1&Fx_Skill_FS_BXS_2&Fx_Skill_FS_BXS_3&Fx_Skill_FS_BXS_3_1&Fx_Skill_FS_BXS_SG&Fx_Skill_FS_SXS&Fx_Skill_FS_SXS_1&Fx_Skill_FS_SXS_2&Skill_Teleport_Begin&Fx_MST_SG_AN&Fx_MST_SG_BING&Fx_MST_SG_DIAN&Fx_MST_SG_DQ&Fx_MST_SG_DU&Fx_MST_SG_FG&Fx_MST_SG_FL&Fx_MST_SG_FL02&Fx_MST_SG_GU0003&Fx_SKI_Spike_SJ&Fx_Skill_SG_AN&Fx_Skill_SG_BING&Fx_Skill_SG_DIAN&Fx_Skill_SG_DQ&Fx_Skill_SG_FL&Fx_Skill_SG_Fire&Fx_Skill_SG_Light&FX_MST_B009_Attack_01&Fx_MST_001_1&Fx_MST_002_1&Fx_MST_004_1&Fx_MST_053_1&Fx_STA_CC&Fx_STA_LM_LL&Fx_STA_MS_SJ&Fx_Skill_FZ_Attact_01&Fx_Skill_FZ_Attact_02&Fx_Skill_FZ_Attact_03&Fx_Skill_FZ_CZNH&Fx_Skill_FZ_CZNH_TB&Fx_Skill_FZ_CZNH_TBSG&Fx_Skill_FZ_DPMJ&Fx_Skill_FZ_DPPZ_01&Fx_Skill_FZ_DPPZ_02&Fx_Skill_FZ_DPPZ_YXZT&Fx_Skill_FZ_DQ_02&Fx_Skill_FZ_GS_1&Fx_Skill_FZ_GS_2&Fx_Skill_FZ_LTYJ&Fx_Skill_FZ_SG&Fx_Skill_FZ_SZ&Fx_Skill_FZ_ZDNH&Fx_Skill_ZS_Attact01&Fx_Skill_ZS_Attact02&Fx_Skill_ZS_Attact03&Fx_Skill_ZS_CF_2&Fx_Skill_ZS_CF_3&Fx_Skill_ZS_DJ&Fx_Skill_ZS_PDNH&Fx_Skill_ZS_XXF";
    private bool r = false;
    string[] allArray = null;

    public int i = 0;
    public UnityEngine.UI.Text tex;
    public Transform ts;
    private GameObject currObj;
    public Transform hideParent;

    public void Awake()
    {
        /*
        string st2322r = "";
        var allFiles = Directory.GetFiles(Application.dataPath + "/Perfect RPG MMO 3D Effect VFX Pack/Prefabs", "*.prefab", SearchOption.AllDirectories);

        //var newR = RandomSortList(new List<string>(allFiles));
        //allFiles = newR.ToArray();

        for (int i = 0; i < allFiles.Length; i++)
        {
            var str = Application.dataPath + "/Perfect RPG MMO 3D Effect VFX Pack/Prefabs/";
            var mmm = allFiles[i].Replace(@"\", "/").Replace(str.Replace(@"\", "/"), "").Replace(".prefab", "");
            if (mmm.IndexOf("/") > -1)
            {
                var m = mmm.Split('/');

                allFiles[i] = m[1];
            }
            else
            {
                allFiles[i] = mmm;
            }
            st2322r += allFiles[i] + "&";

        }

        Debug.LogError(st2322r);
        UnityEngine.GUIUtility.systemCopyBuffer = st2322r;

        return;*/


        allArray = ss.Split('&');

        currObj = GameObject.Instantiate(hideParent.transform.Find(allArray[i]).gameObject);
        currObj.transform.SetParent(ts);
        //currObj.transform.localPosition = Vector3.zero;
        tex.text = "Name: " + i + " 【" + allArray[i] + "】";
    }

    public List<T> RandomSortList<T>(List<T> ListT)
    {
        System.Random random = new System.Random();
        List<T> newList = new List<T>();
        foreach (T item in ListT)
        {
            newList.Insert(random.Next(newList.Count + 1), item);
        }
        return newList;
    }



    public void Update()
    {
        if (ts != null && r)
        {
            ts.transform.Rotate(Vector3.up * Time.deltaTime * 90f);
        }
    }

    public void R()
    {
        r = true;
    }

    public void NotR()
    {
        r = false;
    }

    public void RePlay()
    {
        if (currObj != null)
        {
            currObj.SetActive(false);
            currObj.SetActive(true);
        }
    }

    public void CopyName()
    {
        var s = allArray[i].ToLower().Replace(".prefab", "");
        s = s.Substring(s.IndexOf("/") + 1);
        UnityEngine.GUIUtility.systemCopyBuffer = s;
    }

    public void OnLeftBtClick()
    {
        i--;
        if (i <= 0)
        {
            i = allArray.Length - 1;
        }
        if (currObj != null)
        {
            GameObject.DestroyImmediate(currObj);
        }
        currObj = GameObject.Instantiate(hideParent.transform.Find(allArray[i]).gameObject);
        currObj.transform.SetParent(ts);
        //currObj.transform.localPosition = Vector3.zero;
        tex.text = "Name: " + i + " 【" + allArray[i] + "】";
    }

    public void OnRightBtClick()
    {
        i++;
        if (i >= allArray.Length)
        {
            i = 0;
        }
        if (currObj != null)
        {
            GameObject.DestroyImmediate(currObj);
        }
        currObj = GameObject.Instantiate(hideParent.transform.Find(allArray[i]).gameObject);
        currObj.transform.SetParent(ts);
        //currObj.transform.localPosition = Vector3.zero;
        tex.text = "Name: " + i + " 【" + allArray[i] + "】";
    }
}