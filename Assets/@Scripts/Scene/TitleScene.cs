using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    //UI_TitleScene _titleSceneUI;

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        //SceneType = Define.SceneType.TitleScene;

        ////디폴트 매개변수인데 2인자에만 값을 주고싶을때..
        //Managers.UI.ShowSceneUI<UI_TitleScene>(callback: (titleSceneUI) =>
        //{
        //    _titleSceneUI = titleSceneUI;
        //});

        //StartCoroutine(CoWaitLoad());

        return true;
    }

    IEnumerator CoWaitLoad()
    {
        while (Managers.Data.Loaded() == false)
            yield return null;

        while (Managers.UI.SceneUI == null)
            yield return null;

        while (Managers.Game.IsLoaded == false)
            yield return null;

        //_titleSceneUI.ReadyToStart();
    }
}
