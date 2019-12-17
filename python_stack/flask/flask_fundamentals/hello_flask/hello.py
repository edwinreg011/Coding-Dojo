from flask import Flask, render_template
app = Flask(__name__)


@app.route('/')
def hello_world():
    return render_template('index.html', phrase='hello', times=5)


@app.route('/lists')
def render_lists():
    student_info = [
        {'name': 'Michael', 'age': 35},
        {'name': 'John', 'age': 30},
        {'name': 'Mark', 'age': 25},
        {'name': 'KB', 'age': 27}
    ]
    return render_template("index.html", random_numbers=[3, 1, 5], students=student_info)

# @app.route('/')
# def hello_world():
#     return 'Hello World!'

# @app.route('/dojo')
# def dojo():
#     return 'Dojo!'

# @app.route('/say/<name>')
# def say(name):
#     print(name)
#     return (f'Hi {name}!')

# @app.route('/repeat/<int:number>/<input>')
# def repeat(number, input):
#     print(number * input)
#     return (number * input)

# @app.route('/<input>')
# def error(input):
#     return('Sorry! No response, try again!')


if __name__ == "__main__":
    app.run(debug=True)
