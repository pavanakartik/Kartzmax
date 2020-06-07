import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SaveVehicle } from '../models/vehicle';




@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) { }
  getMakes() {
    // return this.http.get('api/makes').pipe(map((response: any) => response.json()));

    return this.http.get('api/makes');
  }


  getFeatures() {
    return this.http.get("/api/features");
  }




  getVehicle(id) {
    return this.http.get("api/vehicles/" + id);
  }


  getVehicles() {
    return this.http.get('api/vehicles');
  }


  create(vehicle) {


    return this.http.post("api/vehicles", vehicle, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  update(vehicle: SaveVehicle) {
    return this.http.put('api/vehicles/' + vehicle.id, vehicle
    );
  }

  delete(id) {

    return this.http.delete('api/vehicles/' + id);
  }





}

