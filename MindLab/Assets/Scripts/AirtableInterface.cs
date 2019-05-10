using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using AirtableApiClient;

public class AirtableInterface : MonoBehaviour
{

/* 
    Airtable Login Credentials

    ==========================
    =			             =
    = astessel@deakin.edu.au =
    =			             =
    = MindLab2		         =
    =			             =
    ========================== 
*/
    readonly string baseId = "appilY6wWKuTDGDT2";
    readonly string appKey = "keyspPLQhCSkrxQwV";
    readonly string tableName = "AnnotationsTable";

    string filterFormula = "";
    IEnumerable<string> filterFields = new List<string>() {"Author", "Text", "x", "y", "z"};

    public static AirtableInterface Instance;

    private void Awake() 
    {
        Instance = this;
    }

    private bool f_gettingData = false;

    public void GetData()
    {
        if (!f_gettingData)
        {
            getData();
        }
    }

    async private void getData()
    {

        f_gettingData = true;
        string offset = null;
        string errorMessage = null;
        var records = new List<AirtableRecord>();

        using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
        {
        //
        // Use 'offset' and 'pageSize' to specify the records that you want
        // to retrieve.
        // Only use a 'do while' loop if you want to get multiple pages
        // of records.
        //
            Task<AirtableListRecordsResponse> task = airtableBase.ListRecords(
                tableName, 
                "", 
                filterFields, 
                filterFormula, 
                10, 
                10);

            AirtableListRecordsResponse response = await task;

            if (response.Success)
            {
                records.AddRange(response.Records.ToList());
                offset = response.Offset;
            }
            else if (response.AirtableApiError is AirtableApiException)
            {
                errorMessage = response.AirtableApiError.ErrorMessage;
            }
            else
            {
                errorMessage = "Unknown error";
            }
        }
        

        if (!string.IsNullOrEmpty(errorMessage))
        {
            // Error reporting
        }
        else
        {
            // Do something with the retrieved 'records' and the 'offset'
            // for the next page of the record list.
            foreach (AirtableRecord _atr in records)
            {
                var _author = _atr.Fields["Author"];
                var _text = _atr.Fields["Text"];
                var _x = _atr.Fields["x"];
                var _y = _atr.Fields["y"];
                var _z = _atr.Fields["z"];
                Debug.Log(_z.GetType().ToString());
                Debug.Log(_author + ": " + _text + " {" + _x +"," + _y + "," + _z + "}");
                
                Vector3 _v = new Vector3(Convert.ToSingle(_x), Convert.ToSingle(_y), Convert.ToSingle(_z));

                AnnotationManager.Instance.NewAnnotation(_v, (string)_text);
            }
        }

        f_gettingData = false;
    }
    
}
