import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {

  private static readonly UPLOAD_FILE_URL =
    "http://localhost:8090/upload-resume";

  constructor(private http: HttpClient) { }

  // public uploadFiles(filesToUpload: File[],company_name:string) {
  //   let formdata: FormData = new FormData();

  //   for (let i = 0; i < filesToUpload.length; i++) {
  //     formdata.append("file" + i, filesToUpload[i]);
  //   }

  //   return this.http.post(FileUploadService.UPLOAD_FILE_URL, formdata);
  // }

  public uploadFiles(fileToUpload: File) {

        let formdata: FormData = new FormData();
        formdata.append("file", fileToUpload);

    return this.http.post(FileUploadService.UPLOAD_FILE_URL, formdata);
  }

}
