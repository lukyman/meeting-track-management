import { Component, Output, EventEmitter } from '@angular/core';
import { HttpService } from '../../../services/httpservice/http.service';

@Component({
    selector: 'app-taskform',
    templateUrl: './taskform.component.html',
    styleUrls: ['./taskform.component.css']
})
export class TaskFormComponent {
    edit = false;
    @Output() TaskAdded = new EventEmitter();

    constructor(public httpService: HttpService) {

    }

    addTask(data: any) {
        this.httpService.post(data, 'task')
            .subscribe(success => {
                console.log(success)
                this.TaskAdded.emit();
            }, error => {
                console.log(error)
            })
    }
}
