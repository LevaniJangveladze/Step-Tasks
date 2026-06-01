import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgTemplateOutlet, DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NgTemplateOutlet, DecimalPipe],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('directives-task');
  public students: {
  id:      number;
  name:    string;
  grades:  number[];
  active:  boolean;
}[] = [
  { id: 1, name: 'გიორგი',  grades: [90, 85, 92],  active: true  },
  { id: 2, name: 'ნინო',     grades: [70, 65, 60],  active: true  },
  { id: 3, name: 'დავითი',  grades: [55, 48, 50],  active: false },
  { id: 4, name: 'მარიამი', grades: [98, 95, 100], active: true  },
  { id: 5, name: 'ლუკა',    grades: [],              active: true  },
];


getAverage(grades: number[]): number {
  if (grades.length === 0) return 0;
  const sum = grades.reduce((acc, cur) => acc + cur, 0);
  return sum / grades.length;
}

getOverallAverage(): number {
  const withGrades = this.students.filter(s => s.grades.length > 0);
  if (withGrades.length === 0) return 0;

  const sumOfAverages = withGrades.reduce(
    (acc, s) => acc + this.getAverage(s.grades),
    0
  );
  return sumOfAverages / withGrades.length;
}

getGrade(average: number): string {
  if (average >= 90) return 'A';
   if (average >= 80) return 'B';
    if (average >= 70) return 'C';
     return 'F';
}
}
