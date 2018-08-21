import { Component, OnInit, Input } from '@angular/core';
import { HttpService } from '../../../services/httpservice/http.service';

@Component({
    selector: 'app-tasklist',
    templateUrl: './tasklist.component.html',
    styleUrls: ['./tasklist.component.css']
})
export class TaskListComponent  {
   
    @Input() tasks: any[];
    constructor(public httpService: HttpService) {

    }
   
}
