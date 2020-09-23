import { Component } from "@angular/core";
import { FormBuilder, FormControl } from "@angular/forms";
import { debounceTime } from "rxjs/operators";
import { GridParametersModel } from "src/app/components/grid/grid-parameters.model";
import { GridModel } from "src/app/components/grid/grid.model";
import { AppTargetModel } from "../../../../models/appTarget.model";
import { AppTargetService } from "../../../../services/apptarget.service";

@Component({
    selector: "app-list-grid",
    templateUrl: "./grid.component.html"
})
export class AppListGridComponent {
    filters = this.formBuilder.group({
        id: new FormControl(),
        title: new FormControl(),
        url: new FormControl(),
        interval: new FormControl()
    });

    grid = new GridModel<AppTargetModel>();

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly appTargetService: AppTargetService) {
        this.filters.valueChanges.pipe(debounceTime(0)).subscribe(() => this.filter());
        this.load();
    }

    filter() {
        this.grid.parameters = new GridParametersModel();
        this.grid.parameters.filters.addFromFormGroup(this.filters);
        this.load();
    }

    load() {
        this.appTargetService.grid(this.grid.parameters).subscribe((grid) => this.grid = grid);
    }
}
