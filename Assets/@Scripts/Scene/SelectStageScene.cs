using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class SelectStageScene : BaseScene
{
    //UI_SelectStageScene _selectStageSceneUI;

    protected override bool Init()
    {
        
        if (base.Init() == false)
            return false;

        //SceneType = Define.SceneType.SelectStageScene;
        ////대표UI 제작
        //Managers.UI.ShowSceneUI<UI_SelectStageScene>(callback: (selectStageSceneUI) =>
        //{
        //    _selectStageSceneUI = selectStageSceneUI;
        //    _selectStageSceneUI.SetInfo(Managers.Game.HighestChapter);
        //    ShowStory();
        //});

        //Managers.Sound.Clear();
        //Managers.Sound.Play(Sound.Bgm, "Sound_OnStage");


        return true;
    }

    public void ShowStory()
    {
        //처음이면 스토리 보여줌
        //if (Managers.Game.LastStoryID == -1)
        //{
        //    Managers.UI.ShowPopupUI<UI_StoryPopup>($"UI_StoryPopup0");
        //    Managers.Game.LastStoryID = 0;
        //    Managers.Game.SaveGame();
        //}
    }

}
