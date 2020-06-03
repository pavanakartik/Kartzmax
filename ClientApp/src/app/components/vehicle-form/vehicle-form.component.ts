import { MakeService } from './../../services/make.service';
import { Component, OnInit } from '@angular/core';
import { SelectControlValueAccessor } from '@angular/forms';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  makes: any;
  vehicle: any ={};
  models: any;

  constructor(private makeService: MakeService) { }

  ngOnInit() {

    this.makeService.getMakes().subscribe(makes => { this.makes = makes });
  }

  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
  }

}
