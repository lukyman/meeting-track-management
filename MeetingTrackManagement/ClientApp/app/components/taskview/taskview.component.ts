import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/httpservice/http.service';

@Component({
    selector: 'app-taskview',
    templateUrl: './taskview.component.html',
    styleUrls: ['./taskview.component.css']
})
export class TaskViewComponent implements OnInit {

    tasks: any[];

    constructor(public httpService: HttpService) {

    }
    ngOnInit(): void {
        this.getTasks();
    }
    onTaskAdded() {
        this.getTasks()
    }
    getTasks() {
        this.httpService.get('task')
            .subscribe(success => {
                console.log(success.json())
                this.tasks = success.json().data;
            }, error => {
                console.log(error)
            })
    }
}
