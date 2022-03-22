using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenRecorder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Recorder _rec;
        Stream _outStream;
        void CreateRecording()
        {
            //string videoPath = Path.Combine(Path.GetTempPath(), "test.mp4");
            _rec = Recorder.CreateRecorder();
            _rec.OnRecordingComplete += Rec_OnRecordingComplete;
            _rec.OnRecordingFailed += Rec_OnRecordingFailed;
            _rec.OnStatusChanged += Rec_OnStatusChanged;
            //Record to a file
            string videoPath = Path.Combine(Path.GetTempPath(), "test.mp4");
            _rec.Record(videoPath);
            //..Or to a stream
            //_outStream = new MemoryStream();
            //_rec.Record(_outStream);
        }
        void EndRecording()
        {
            _rec.Stop();
        }
        private void Rec_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            //Get the file path if recorded to a file
            string path = e.FilePath;
            //or do something with your stream
            //... something ...
            _outStream?.Dispose();
        }
        private void Rec_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
        {
            string error = e.Error;
            _outStream?.Dispose();
        }
        private void Rec_OnStatusChanged(object sender, RecordingStatusEventArgs e)
        {
            RecorderStatus status = e.Status;
        }



        private void Opt()
        {
            RecorderOptions options = new RecorderOptions
            {
                RecorderMode = RecorderMode.Video,
                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                //depending on encoder settings and system specifications.
                IsThrottlingDisabled = false,
                //Hardware encoding is enabled by default.
                IsHardwareEncodingEnabled = true,
                //Low latency mode provides faster encoding, but can reduce quality.
                IsLowLatencyEnabled = false,
                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                IsMp4FastStartEnabled = false,
                AudioOptions = new AudioOptions
                {
                    Bitrate = AudioBitrate.bitrate_128kbps,
                    Channels = AudioChannels.Stereo,
                    IsAudioEnabled = true
                },
                VideoOptions = new VideoOptions
                {
                    BitrateMode = BitrateControlMode.UnconstrainedVBR,
                    Bitrate = 8000 * 1000,
                    Framerate = 60,
                    IsFixedFramerate = true,
                    EncoderProfile = H264Profile.Main
                },
                MouseOptions = new MouseOptions
                {
                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                    IsMouseClicksDetected = true,
                    MouseClickDetectionColor = "#FFFF00",
                    MouseRightClickDetectionColor = "#FFFF00",
                    MouseClickDetectionRadius = 30,
                    MouseClickDetectionDuration = 100,
                    IsMousePointerEnabled = true,

                },
            };


            List<string> inputDevices = Recorder.GetSystemAudioDevices(AudioDeviceSource.InputDevices);
            List<string> outputDevices = Recorder.GetSystemAudioDevices(AudioDeviceSource.OutputDevices);
            //string selectedOutputDevice = //select one of the devices.. Passing empty string or null uses system default playback device.
            //string selectedInputDevice = //select one of the devices.. Passing empty string or null uses system default recording device.
            var audioOptions = new AudioOptions
            {
                IsAudioEnabled = true,
                IsOutputDeviceEnabled = true,
                IsInputDeviceEnabled = true,
                //AudioOutputDevice = selectedOutputDevice,
                // AudioInputDevice = selectedInputDevice
            };

            ////crop to a 400x400 pixel square at x=400,y=400. Passing 0 for these values will default to full screen recording.
            //int left = 400;
            //int top = 400;
            //int right = 800;
            //int bottom = 800;
            ////DeviceName in the form \\.\DISPLAY1. Typically you would enumerate system monitors and select one. Default monitor is used if no valid input is given.
            //string monitorDeviceName = System.Windows.Forms.Screen.PrimaryScreen.DeviceName;
            //RecorderOptions options = new RecorderOptions
            //{
            //    DisplayOptions = new DisplayOptions(monitorDeviceName, left, top, right, bottom)
            //}
            _rec = Recorder.CreateRecorder(options);


          

          
        }
    }
}
