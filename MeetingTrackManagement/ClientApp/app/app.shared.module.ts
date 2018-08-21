import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { TaskFormComponent } from './components/taskview/taskform/taskform.component';
import { TaskListComponent } from './components/taskview/tasklist/tasklist.component';
import { TaskViewComponent } from './components/taskview/taskview.component';
import { EventTimelineComponent } from './components/EventTimeline/eventtimeline.component';
import { HttpService } from './services/httpservice/http.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        TaskViewComponent,
        TaskFormComponent,
        TaskListComponent,
        EventTimelineComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'task', component: TaskViewComponent },
            { path: 'timeline', component: EventTimelineComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        HttpService
    ]
})
export class AppModuleShared {
}
