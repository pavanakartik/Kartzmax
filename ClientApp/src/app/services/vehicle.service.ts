import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';



@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) {

  }

  getMakes() {

    var makes= this.http.get('api/makes');

    console.log("Makes: "+ makes);

    return makes ;

  
  }

  getFeatures(){
    return  this.http.get("api/features");
 }

 create(vehicle){

  return this.http.post("api/vehicles", vehicle, {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  });
 }
}
