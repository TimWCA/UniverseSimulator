using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;

public class ShowHelp : MonoBehaviour
{
    public void onClick()
    {
        MessageBox.Show("????? ??????? ??????? ??? ??????, ??????? ?????????????? ????????? ? ????? ? ?????? ????? ??????. \n" +
            "???????, ?????????? ? ????? ???????? ? ???????? ??????? ??. ??? ??????, ??? ???? ???????? ????? ? ??, ?? ?????????? ????? ???????? ? ?. " +
            "? ???? ????? ????????? ? ?????? (?? * 1000), ?? ?????????? ??????????? ? ?? (? * 1000). ??????????? ??? ???? ??????? ? 1e+9.\n" +
            "???? ???????????? ?????? ?????????? ??????? ?? ?????? ????????? (0; 0; 0). \n" +
            "???? ????????? ?????? ????, ??????? ????????? ??????? ??? ??? ????????, ????? ?? ????????. \n" +
            "????? ?? ?????? ??????? ??????? ??? ??? ???????? ? ??????? ??? ???????? ????????. \n \n" +
            "????? ????, ??? ?? ??????? ??? ????????, ??????? ?????? ???????? ???????? ??? ???????? ???????, ? ?????? ???????? ?? ??????. " +
            "????? ?? ?????? ???????? ????? ? ??????? ???????, ?????? ?? ? ????? ? ??????? ??? ?? ???????. \n \n" +
            "??? ????????? ??????? ? ????????? ??????????? ???????? ????????? ????????. ??? ?????????/?????????? ?????? ??????? ???. " +
            "?? ?????? ????????? ????????? ? ???? ? ????????? ???? ? ?????????? ? ??????? ?????? ??????????? ? ???????????.", "??????");
    }
}
