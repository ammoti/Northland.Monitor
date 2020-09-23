import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { AppButtonModule } from "src/app/components/button/button.module";
import { AppInputModule } from "src/app/components/input/input.module";
import { AppLabelModule } from "src/app/components/label/label.module";
import { AppSelectCommentModule } from "src/app/components/select/comment/comment.module";
import { AppTargetComponent } from "./apptarget.component";
import { AppListGridModule } from "./grid/grid.module";

const ROUTES: Routes = [{ path: "", component: AppTargetComponent }];

@NgModule({
    declarations: [AppTargetComponent],
    imports: [
        RouterModule.forChild(ROUTES),
        AppListGridModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AppButtonModule,
        AppLabelModule,
        AppSelectCommentModule,
        AppInputModule
    ],
})
export class AppTargetModule {}
