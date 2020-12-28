using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App22.Helper
{
    class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public ImageView userProfile { get; set; }
        public TextView time { get; set; }
        public TextView userName { get; set; }
        public TextView issueInfo { get; set; }

        public RecyclerViewHolder(View itemView) : base(itemView)
        {
            userProfile = itemView.FindViewById<ImageView>(Resource.Id.circleImageView1_notifications);
            userName = itemView.FindViewById<TextView>(Resource.Id.tv_name_notification);
            time = itemView.FindViewById<TextView>(Resource.Id.tv_time_noti);
            issueInfo = itemView.FindViewById<TextView>(Resource.Id.tv_info_notification);
        }

    }
    class RecyclerViewAdapter : RecyclerView.Adapter
    {
        private List<Data> lstData = new List<Data>();

        public RecyclerViewAdapter(List<Data> lstData)
        {
            this.lstData = lstData;
        }

        public override int ItemCount
        {
            get
            {
                return lstData.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder viewHolder = holder as RecyclerViewHolder;
            byte[] arr0 = Convert.FromBase64String(lstData[position].userProfile); //userProfile
            Bitmap b0 = BitmapFactory.DecodeByteArray(arr0, 0, arr0.Length);
            viewHolder.userProfile.SetImageBitmap(b0);
            
            viewHolder.userName.Text = lstData[position].userName;
            viewHolder.issueInfo.Text = lstData[position].issueInfo;
            viewHolder.time.Text = lstData[position].tvtime_noti;
            //viewHolder.imageview.SetImageResource(lstData[position].imageid);
            //viewHolder.Description.Text = lstData[position].description;

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.notification_items, parent, false);
            return new RecyclerViewHolder(itemView);
        }
    }
}