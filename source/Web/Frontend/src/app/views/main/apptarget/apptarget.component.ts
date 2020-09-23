import { Component } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { AppTargetService } from "src/app/services/apptarget.service";

@Component({
    selector: "app-list",
    templateUrl: "./apptarget.component.html",
})
export class AppTargetComponent {
    disabled = false;

    // tslint:disable-next-line: member-ordering
    form2 = this.formBuilder.group({
        title: ["", Validators.required],
        url: ["", Validators.required],
        interval: ["", Validators.required],
    });

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly appTargetService: AppTargetService
    ) {}

    addNew() {
        console.log("Çalıştı", this.form2.value);

        this.appTargetService.add(this.form2.value).subscribe((value) => {
            console.log(value);
        });
    }
}
