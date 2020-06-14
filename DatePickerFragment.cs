using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace AndroidAerolinea
{
    class DatePickerFragment : DialogFragment, DatePickerDialog.IOnDateSetListener
    {
        public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();
        Action<DateTime> _dateSelectedHandler = delegate { };
        static DateTime currently;

        public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected, DateTime fecha)
        {
            DatePickerFragment frag = new DatePickerFragment();
            frag._dateSelectedHandler = onDateSelected;
            currently = fecha;
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DatePickerDialog dialogDate = new DatePickerDialog(Activity, this, currently.Year, currently.Month - 1, currently.Day);
            return dialogDate;
        }


        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            // Note: monthOfYear is a value between 0 and 11, not 1 and 12!
            DateTime selectedDate = new DateTime(year, month + 1, dayOfMonth);
            Log.Debug(TAG, selectedDate.ToLongDateString());
            _dateSelectedHandler(selectedDate);
        }
    }
}