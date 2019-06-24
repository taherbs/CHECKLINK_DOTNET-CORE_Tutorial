# This Makefile will automate the project build/run

SERVICE_NAME = "checklinksconsole"

.PHONY: build
build:
	docker build -f Dockerfile -t "$(SERVICE_NAME)" .

.PHONY: run
run:
	docker run --rm "$(SERVICE_NAME)"

.PHONY: ssh
ssh:
	docker run --rm -it --entrypoint=bash "$(SERVICE_NAME)"