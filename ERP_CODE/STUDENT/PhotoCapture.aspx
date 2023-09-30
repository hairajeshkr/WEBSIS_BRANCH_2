<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhotoCapture.aspx.cs" Inherits="STUDENT_PhotoCapture" StyleSheetTheme="SkinFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <div>
            <video id="video" runat="server" width="320" height="240" autoplay></video>
            <button id="capture" runat="server">Capture</button>
            <canvas id="canvas"  width="320" height="240" style="display:none";"></canvas>
            <img id="capturedImage" runat="server" alt="Captured Image" width="320" height="240" style="display:normal;" >
            
             
            <td align="center">
           <input type="button" id="btnCrop" value="Crop" style="display: none" />
           <input type="hidden" name="imgX1" id="imgX1" />
           <input type="hidden" name="imgY1" id="imgY1" />
           <input type="hidden" name="imgWidth" id="imgWidth" />
           <input type="hidden" name="imgHeight" id="imgHeight" />
           <input type="hidden" name="imgCropped" id="imgCropped" />

                 <canvas id="canvas1"  width="320" height="240" style="display:none";"></canvas>
                 <img id="Img1" runat="server" alt="Captured Image" width="320" height="240" style="display:normal;" >
                <input type="range" id="brightnessControl" min="-100" max="100" value="0" step="1">
                <input type="button" id="btnUpload" value="Upload" disabled="disabled" />
       </td>
        </div>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-jcrop/0.9.9/js/jquery.Jcrop.min.js"></script>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', () => {
            const video = document.getElementById('video');
            const canvas = document.getElementById('canvas');
            const capturedImage = document.getElementById('capturedImage');
            const captureButton = document.getElementById('capture');
            const brightnessControl = document.getElementById('brightnessControl'); // Added


            if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
                navigator.mediaDevices.getUserMedia({ video: true })
                    .then(function (stream) {
                        // Display the webcam feed in the video element
                        video.srcObject = stream;
                    })
                    .catch(function (error) {
                        console.error('Error accessing the webcam:', error);
                    });

                // Capture image from video feed
                captureButton.addEventListener('click', function () {
                    canvas.width = 320;
                    canvas.height = 240;
                    canvas.getContext('2d').drawImage(video, 0, 0, canvas.width, canvas.height);

                    // Convert canvas content to a data URL (base64)
                    const capturedImageData = canvas.toDataURL('image/jpeg');

                    // Set the captured image source and display it
                    capturedImage.src = capturedImageData;

                    // increaseBrightness('canvas', 80);

                    //// Enable brightness control
                    brightnessControl.removeAttribute('disabled');

                    ////$("#btnUpload").removeAttr("disabled");
                    // Call the saveCapturedImage function to send the captured image data to the server
                    $('#capturedImage').Jcrop({
                        onChange: SetCoordinates,
                        onSelect: SetCoordinates
                    });

                    // Set the captured image source and display it

                });

            } else {
                console.error('Webcam not supported.');
            }

            // Function to adjust brightness based on the control
            brightnessControl.addEventListener('input', function () {
                const brightnessFactor = parseInt(brightnessControl.value, 10);
                adjustBrightness('canvas1', brightnessFactor);
            });

        });

        function SetCoordinates(c) {
            $('#imgX1').val(c.x);
            $('#imgY1').val(c.y);
            $('#imgWidth').val(c.w);
            $('#imgHeight').val(c.h);
            $('#btnCrop').show();
        };

        $('#btnCrop').click(function () {
            var x1 = $('#imgX1').val();
            var y1 = $('#imgY1').val();
            var width = $('#imgWidth').val();
            var height = $('#imgHeight').val();
            var canvas = $("#canvas1")[0];
            var context = canvas.getContext('2d');
            var img = new Image();
            img.onload = function () {
                canvas.height = height;
                canvas.width = width;
                context.drawImage(img, x1, y1, width, height, 0, 0, width, height);
                $('#imgCropped').val(canvas.toDataURL());

                const capturedImageData = canvas.toDataURL('image/jpeg');

                //increaseBrightness('canvas1', 80);
                changeBackground('canvas1', [255, 0, 0, 255]);
                Img1.src = capturedImageData;
                $("#btnUpload").removeAttr("disabled");
                $('[id*=btnUpload]').show();
            };
            img.src = $('#capturedImage').attr("src");

        });

        $("#btnUpload").click(function () {
            $.ajax({
                type: "POST",
                url: "PhotoUpload.aspx/SaveCapturedImage",
                data: "{data: '" + $("#Img1")[0].src + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) { }
            });
        });

        function adjustBrightness(canvasId, brightnessFactor) {
            const canvas = document.getElementById(canvasId);
            const ctx = canvas.getContext('2d');

            // Get the image data from the canvas
            const imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
            const data = imageData.data;

            // Adjust the brightness of each pixel
            for (let i = 0; i < data.length; i += 4) {
                // Modify the red, green, and blue values
                data[i] = clamp(data[i] + brightnessFactor, 0, 255); // Red
                data[i + 1] = clamp(data[i + 1] + brightnessFactor, 0, 255); // Green
                data[i + 2] = clamp(data[i + 2] + brightnessFactor, 0, 255); // Blue
            }

            // Put the modified image data back on the canvas
            ctx.putImageData(imageData, 0, 0);
        }

        function changeBackground(canvasId, newBackgroundColor) {
            const canvas = document.getElementById(canvasId);
            const ctx = canvas.getContext('2d');

            // Get the image data from the canvas
            const imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
            const data = imageData.data;

            // Define the color you want to replace (white in this example)
            const targetColor = [255, 255, 255, 255];

            // Define the tolerance for color replacement (adjust as needed)
            const tolerance = 50;

            // Loop through each pixel and replace the target color
            for (let i = 0; i < data.length; i += 4) {
                const r = data[i];
                const g = data[i + 1];
                const b = data[i + 2];

                // Check if the pixel color is similar to the target color
                if (
                    Math.abs(r - targetColor[0]) < tolerance &&
                    Math.abs(g - targetColor[1]) < tolerance &&
                    Math.abs(b - targetColor[2]) < tolerance
                ) {
                    // Replace the pixel color with the new background color
                    data[i] = newBackgroundColor[0];
                    data[i + 1] = newBackgroundColor[1];
                    data[i + 2] = newBackgroundColor[2];
                    data[i + 3] = newBackgroundColor[3]; // Alpha
                }
            }

            // Put the modified image data back on the canvas
            ctx.putImageData(imageData, 0, 0);
        }

    </script>

</body>
</html>
