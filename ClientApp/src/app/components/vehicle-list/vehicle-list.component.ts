import { Component, OnInit } from '@angular/core';
import { Vehicle, SaveVehicle } from 'src/app/models/vehicle';
import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {


  vehicles: any;


  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {

    this.vehicleService.getVehicles().subscribe(vehicles => this.vehicles = vehicles);
  }

}
