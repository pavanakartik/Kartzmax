import { KeyValuePair } from './../../models/vehicle';
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

  makes: any;
  filter: any = {};


  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes()
      .subscribe(makes => this.makes = makes);

    this.populateVehicles();
  }

  private populateVehicles() {
    this.vehicleService.getVehicles(this.filter)
      .subscribe(vehicles => this.vehicles = vehicles);

  }

  onFilterChange() {
    this.populateVehicles();

  }

  resetFilter() {
    this.filter = {};
    this.onFilterChange();
  }

}
