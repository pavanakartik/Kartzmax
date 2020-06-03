import { MakeService } from './../../services/make.service';
import { Component, OnInit } from '@angular/core';
import { SelectControlValueAccessor } from '@angular/forms';
import { FeatureService } from 'src/app/services/feature.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  makes: any;
  vehicle: any = {};
  models: any;
  features:any;

  constructor(private makeService: MakeService, private featureService: FeatureService) { }

  ngOnInit() {

    this.makeService.getMakes().subscribe(makes => { this.makes = makes });
    this.featureService.getFeatures().subscribe(features => {this.features = features });

  }

  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
  }
  onFeatureToggle(featureId, $event) {
    if ($event.target.checked) {
      this.vehicle.features.push(featureId);
    }

    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }

  }

}
