import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { GridParametersModel } from "src/app/components/grid/grid-parameters.model";
import { GridService } from "src/app/components/grid/grid.service";
import { AppTargetModel } from "../models/appTarget.model";

@Injectable({ providedIn: "root" })
export class AppTargetService {
    private readonly url = "targetApp";

    constructor(
        private readonly http: HttpClient,
        private readonly gridService: GridService
    ) {}

    add(model: AppTargetModel) {
        return this.http.post<number>(this.url, model);
    }

    delete(id: number) {
        return this.http.delete(`${this.url}/${id}`);
    }

    get(id: number) {
        return this.http.get<AppTargetModel>(`${this.url}/${id}`);
    }

    grid(parameters: GridParametersModel) {
        return this.gridService.get<AppTargetModel>(`${this.url}/grid`, parameters);
    }

    list() {
        return this.http.get<AppTargetModel[]>(this.url);
    }

    update(model: AppTargetModel) {
        return this.http.put(`${this.url}/${model.id}`, model);
    }
}
