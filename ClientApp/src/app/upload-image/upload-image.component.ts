import { Component, OnInit } from '@angular/core';
import { FileUploadService } from '../Services/file-upload.service';

@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.css']
})
export class UploadImageComponent implements OnInit {

  url:any;
  fileFormatsSupported;
  fileSelected:File;

  constructor(private fileUploadService:FileUploadService) { }

  ngOnInit() {
  }

  public upload() {

    this.fileUploadService.uploadFiles(this.fileSelected).subscribe(
      response => console.log("set any success actions..." + response),
      error => {
        console.log("set any error actions..." + JSON.stringify(error));
      },
      () => {
        console.log("Sucessful");
      }
    );
     
      // window.location.href = 'http://localhost:4200/company';
  }

   onChange($event) {

    if ($event.target.files && $event.target.files[0]) {

      this.fileSelected=$event.target.files[0];

      var reader = new FileReader();

      reader.readAsDataURL(this.fileSelected); // read file as data url

      reader.onload = (event) => { // called once readAsDataURL is completed

        this.url =(<FileReader> event.target).result;
      }
    }

    console.log(this.fileSelected.type);

      // if(!this.fileFormatsSupported.includes(this.fileSelected.type))
      // alert("File Format Not Supported");    

  }

}
