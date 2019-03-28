var ImageUploaderPlugin = {
    ImageUploaderCaptureClick: function() {
      console.log("Checking if element is present")
      if (!document.getElementById('ImageUploaderInput')) {
        var fileInput = document.createElement('input');
        fileInput.setAttribute('type', 'file');
        fileInput.setAttribute('id', 'ImageUploaderInput');
        fileInput.style.visibility = 'hidden';
        fileInput.onclick = function (event) {
          this.value = null;
        };
        console.log("Assigning OnChange")
        fileInput.onchange = function (event) {
          SendMessage('Canvas', 'FileSelected', URL.createObjectURL(event.target.files[0]));
        }
        document.body.appendChild(fileInput);
      }

      console.log("Listener for file dialog")
      var OpenFileDialog = function() {
        document.getElementById('ImageUploaderInput').click();
        document.getElementById('#canvas').removeEventListener('click', OpenFileDialog);
      };

      console.log("Adding Listener")
      document.getElementById('#canvas').addEventListener('click', OpenFileDialog, false);
    },
    ImageUploaderInit: function(){
      console.log("Initializing");
      var fileInput = document.createElement('input');
        fileInput.setAttribute('type', 'file');
        fileInput.setAttribute('id', 'ImageUploaderInput');
        fileInput.style.visibility = 'hidden';
        fileInput.onclick = function (event) {
          this.value = null;
        }
        console.log("Assigning OnChange")
        fileInput.onchange = function (event) {
          SendMessage('GameUnlocker', 'FileSelected', URL.createObjectURL(event.target.files[0]));
        }
        console.log("Appenging file input");
        document.body.appendChild(fileInput);

        console.log("Listener for file dialog")
      var OpenFileDialog = function() {
        document.getElementById('ImageUploaderInput').click();
        //document.getElementById('#canvas').removeEventListener('click', OpenFileDialog);
      };

      console.log("Adding Listener")
      document.getElementById('#canvas').addEventListener('click', OpenFileDialog, false);
      
        console.log("----------------------------")
        console.log("----Initialisation done-----")
        console.log("----------------------------")

    }
  };
  mergeInto(LibraryManager.library, ImageUploaderPlugin);
